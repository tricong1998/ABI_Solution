using ABI_DCH.Common;
using ABI_DCH.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace ABI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region static, const var
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public const string UTF8_HEADER = "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
        #endregion

        #region attributes
        ABIExam exam;
        System.Windows.Forms.Screen screen;
        #endregion

        public MainWindow()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }

        #region util function
        /// <summary>
        /// init new exam
        /// </summary>
        private void InitAnExam()
        {
            exam = new ABIExam
            {
                // long task
                QAPairs = new LoadWordQuestions().Load(out string workspace)
            };
            exam.ClientWorkspace = workspace;
            exam.WordApplication = new Word.Application
            {
                Visible = true
            };
            exam.MapIndexDocuments = new Dictionary<int, Word.Document>();
            OpenAllFiles(exam.QAPairs, exam.MapIndexDocuments, exam.WordApplication);
            exam.WordApplication.DocumentOpen += OpenDocumentEvent;
            var itemSource = Utils.ConvertListQuestions(exam.QAPairs);
            DataContext = itemSource;
            question_selection.SelectedIndex = 0;
        }

        /// <summary>
        /// open all files require for questions
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="mapIndexDocuments"></param>
        /// <param name="wordApplication"></param>
        private void OpenAllFiles(List<IQAPair> pairs, Dictionary<int, Word.Document> mapIndexDocuments, Word.Application wordApplication)
        {
            foreach (var pair in pairs)
            {
                IQuestion question = pair.Question;
                string path = question.File.Path;
                // if open question, not open it :D
                if (question is OpenWFileQuestion openQuestion)
                {
                    word_uc.HandleOpenQuestion(openQuestion, mapIndexDocuments, wordApplication);
                }
                else
                    word_uc.OpenDocument(question, mapIndexDocuments, wordApplication);
            }
        }
        #endregion

        #region controls' events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            screen = System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(this).Handle);

            InitAnExam();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.SaveAll(exam.MapIndexDocuments);
            Utils.CloseAll(exam.MapIndexDocuments);
            exam.WordApplication.Quit();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //this.Topmost = true;
            //this.Activate();
        }

        /// <summary>
        /// when user open a document (open file question)
        /// </summary>
        /// <param name="doc"></param>
        private void OpenDocumentEvent(Word.Document doc)
        {
            logger.Debug(doc.FullName);
            if (doc == null)
                return;
            Application.Current.Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    int index = question_selection.SelectedIndex;
                    exam.MapIndexDocuments[exam.QAPairs[index].Question.Index] = doc;
                    word_uc.FitIntoArea(exam.WordApplication);
                }));
        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            // submit answer here
            int index = question_selection.SelectedIndex; //index of current question
            UpdateAnswer(exam.QAPairs[index]);
            CheckFinishToSubmitAll();
        }

        private void question_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && e.RemovedItems.Count > 0)
            {
                var _old = e.RemovedItems[0];
                if (_old is QuestionVisual oldQV)
                {
                    var oldQuestion = oldQV.Question;
                    SaveUserTask(oldQuestion);
                }
            }
            var _new = e.AddedItems[0] as QuestionVisual;
            web_question.NavigateToString(UTF8_HEADER + _new.Question.HtmlContent);
            int index = question_selection.SelectedIndex;
            IQuestion question = exam.QAPairs[index].Question;
            string path = question.File.Path;
            if (question is OpenWFileQuestion openQuestion)
            {
                word_uc.HandleOpenQuestion(openQuestion, exam.MapIndexDocuments, exam.WordApplication);
            }
            else
                word_uc.OpenDocument(question, exam.MapIndexDocuments, exam.WordApplication);
        }
        #endregion

        #region common actions
        // update answer here
        public void UpdateAnswer(IQAPair qaPair)
        {
            
        }

        private void SaveUserTask(IQuestion question)
        {
            Utils.Save(question.Index, exam.MapIndexDocuments);
        }

        public void CheckFinishToSubmitAll()
        {
            bool done = true;
            foreach (IQAPair pair in exam.QAPairs)
            {
                if (pair.Answer == null)
                {
                    done = false;
                    break;
                }
            }
            if (done)
            {
                SubmitAll();
            }
        }

        public void SubmitAll()
        {
            // call to ExamSubmission.SubmitAll
        }
        #endregion
    }
}