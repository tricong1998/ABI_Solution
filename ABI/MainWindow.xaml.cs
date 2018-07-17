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
            InitAnExam();
            
        }

        #region util function
        private void InitAnExam()
        {
            exam = new ABIExam();
            var questions = new LoadWordQuestions().Load();
            var _QAPairs = new List<IQAPair>();
            foreach (var question in questions)
            {
                _QAPairs.Add(new ABIQAPair(question, null));
            }
            exam.QAPairs = _QAPairs;
            var itemSource = Utils.ConvertListQuestions(questions);
            //itemSource[0].IsSelected = true;
            DataContext = itemSource;
            question_selection.SelectedIndex = 0;
        }
        #endregion

        #region controls' events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            screen = System.Windows.Forms.Screen.FromHandle(
                new System.Windows.Interop.WindowInteropHelper(this).Handle);
            this.Left = 0;
            this.Width = screen.Bounds.Width;
            this.Top = screen.Bounds.Height - this.Height;
            //new OpenDocument().Open(
            //    @"C:\Users\duongtd\Desktop\DuongTD_ThanhTich_v1.1.doc",
            //    new Rect(new Point(0, 0), new Size(screen.Bounds.Width, screen.Bounds.Height - this.Height)));
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Activate();
        }
        #endregion

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            // submit answer here
            int index = question_selection.SelectedIndex; //index of current question
            IAnswer answer = PackageAnswer(exam.QAPairs[index].Question);
            exam.QAPairs[index].Answer = answer;

            CheckFinishToSubmitAll();
        }

        private void question_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _new = e.AddedItems[0] as QuestionVisual;
            web_question.NavigateToString(UTF8_HEADER + _new.Question.HtmlContent);

            // update ui here
        }

        #region common actions
        /// <summary>
        /// return appropriate answer (type) based-on question type
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public IAnswer PackageAnswer(IQuestion question)
        {
            // @Cong implement here
            // e.g., if (question is CompareWFileQuestion) return new CompareWFileAnswer
            IAnswer re = null;
            if (question is CompareWFileQuestion)
            {
                re = new CompareWFileAnswer();
                ((CompareWFileAnswer)re).File = file_submiss;
                // save path to file answer here
            }
            else if (question is OpenWFileQuestion)
            {
                re = new OpenWFileAnswer();
                ((OpenWFileAnswer)re).file_to_open = "";
            }
            // .. so on
            return re;
            //throw new NotImplementedException();
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
            foreach (IQAPair pair in exam.QAPairs)
            {
                IQuestion question = pair.Question;
                if (question is OpenFileQuestion)
                {
                    // call to OpenWFile.CheckOpened(question.file_to_open);
                }
                if (question is CompareWFileQuestion questionCur)
                {         
                    Word.Application application = new Word.Application();
                    Word.Document anwser = application.Documents.Open(questionCur);
                    Word.Document correctAnwser = application.Documents.Open();
                    ABIW_Document document1 = new ABIW_Document(anwser);
                    ABIW_Document document2 = new ABIW_Document(correctAnwser);
                    switch (question.type_l2)
                    {
                        case 9:
                            CompareWFont compare = new CompareWFont();
                            compare.Compare(document1, document2);
                            break;
                        default:
                            break;
                    }
                        // call to CompareWFont.Compare()
                }
            }
            // implement total result here
        }
        #endregion
    }
}