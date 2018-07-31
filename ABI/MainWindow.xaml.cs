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
        #endregion

        public const string UTF8_HEADER = "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
        #region attributes
        ABIExam exam;
        System.Windows.Forms.Screen screen;

        #endregion

        public MainWindow()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
            web_question.NavigateToString("<h1>Question 1</h1>");

        }

        #region util function
        private void InitAnExam()
        {
            exam = new ABIExam
            {
                QAPairs = new LoadWordQuestions().Load()
            };
            var itemSource = Utils.ConvertListQuestions(exam.QAPairs);
            DataContext = itemSource;
            question_selection.SelectedIndex = 0;

        }
        #endregion

        #region controls' events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            screen = System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(this).Handle);

            InitAnExam();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //this.Topmost = true;
            //this.Activate();
        }
        #endregion

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            int index = question_selection.SelectedIndex; //index of current question
            UpdateAnswer(exam.QAPairs[index]);
            CheckFinishToSubmitAll();
        }

        private void question_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _new = e.AddedItems[0] as QuestionVisual;
            web_question.NavigateToString(UTF8_HEADER + _new.Question.HtmlContent);
            int index = question_selection.SelectedIndex;
            string path = exam.QAPairs[index].Question.File.Path;

            //if (word_uc.Document is null)
            //{
            //    word_uc.OpenDocument(path);
            //}
            //else
            //{
                //word_uc.Save();
                //word_uc.Close();
                word_uc.OpenDocument(path);
            //}
        }

        #region common actions
        // update answer here
        public void UpdateAnswer(IQAPair qaPair)
        {
            
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
            word_uc.SaveCloseAllDocuments();
            if (exam.Score == null)
            {
                exam.Score = new ScoreResult(0);
            }        
            foreach (IQAPair pair in exam.QAPairs)
            {
                IQuestion question = pair.Question;
                if (question is OpenWFileQuestion)
                {
                    OpenWFile openWFile = new OpenWFile();
                    pair.Result = openWFile.CheckOpened(question.File.Path);
                    if (pair.Result is ComparisonResult comparisonFont)
                        if (comparisonFont.Result == ComparisonResultIndicate.equal)
                            exam.Score.Score++;
                    // call to OpenWFile.CheckOpened(question.file_to_open);
                }
                else if (question is CompareWFileQuestion questionCur)
                {         

                    Word.Application application = new Word.Application();                    
                    Word.Document anwser = application.Documents.Open(question.File.Path);
                    Word.Document correctAnwser = application.Documents.Open(pair.CorrectAnswer.File.Path);
                    ABIW_Document document1 = new ABIW_Document(anwser);
                    ABIW_Document document2 = new ABIW_Document(correctAnwser);  
                    switch (questionCur.Type_l2)
                    {                       
                        case 9 : case 10 : case 11 : case 12 : case 13 : case 14:
                            CompareWFont compare = new CompareWFont();
                            pair.Result = compare.Compare(document1, document2);
                            if (pair.Result is ComparisonResult comparisonFont)
                                if (comparisonFont.Result == ComparisonResultIndicate.equal)
                                   exam.Score.Score++;
                            break;
                        case 16: case 17: case 18:  case 19: case 21:
                            CompareWParagraph compareWParagraph = new CompareWParagraph();
                            pair.Result = compareWParagraph.Compare(document1, document2);
                            if (pair.Result is ComparisonResult comparisonParagraph)
                            {                                
                                if(comparisonParagraph.Result == ComparisonResultIndicate.equal)
                                    exam.Score.Score++;
                            }
                            break;                   
                    }
                    anwser.Close();
                    correctAnwser.Close();
                    application.Quit();
                }
                //else if (question is )
            }
            // implement total result here
            MessageBox.Show("Score: " + exam.Score.Score);
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //word_uc.Save();
            //word_uc.Close();
            word_uc.Quit();
            //MessageBox.Show("abc");
        }
    }
}