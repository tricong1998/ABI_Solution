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
            web_question.NavigateToString(UTF8_HEADER + _QAPairs[0].Question.HtmlContent);
        }
        #endregion

        #region controls' events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            screen = System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(this).Handle);
            //this.Left = 0;
            //this.Width = screen.Bounds.Width;
            //this.Top = screen.Bounds.Height - this.Height;
            int w = (int)word_uc.ActualWidth;
            int h = (int)word_uc.ActualHeight;
            Thickness x = word_uc.Margin;
            word_uc.OpenDocument(@"E:\1 - Copy.docx");            
            //new OpenDocument().Open(
            //    @"G:\abi\word_module\Word_Table\doc1.docx",
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
        /// return appropriate answer (type) based-on question type (lưu lại những câu hỏi đã submit)
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
               // ((CompareWFileAnswer)re).CorrectAnswer.Path = question.Answer;
                // save path to file answer here
            }
            else if (question is OpenFileQuestion openFileQuestion)
            {
                re = new OpenWFileAnswer();
                ((OpenWFileAnswer)re).File = new ABI_WFile()
                {
                    Path = question.Answer
                };
               // ((OpenWFileAnswer)re).File.Path = question.Question;
            }
            else if (question is CompareWFileClose)
            {
                re = new CloseWFileAnswer();
              //  ((CloseWFileAnswer)re).File.Path = question.Question;
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
            int score = 0;
            foreach (IQAPair pair in exam.QAPairs)
            {
                IQuestion question = pair.Question;
                if (question is OpenFileQuestion)
                {
                    // call to OpenWFile.CheckOpened(question.file_to_open);
                }
                else if (question is CompareWFileQuestion questionCur)
                {
                    word_uc.Save();
                    word_uc.Close();
                    Word.Application application = new Word.Application();
                    Word.Document anwser = application.Documents.Open(questionCur.CorrectAnswer);
                    try
                    {
                        Word.Document correctAnwser = application.Documents.Open(questionCur.Answer);
                        ABIW_Document document1 = new ABIW_Document(anwser);
                        ABIW_Document document2 = new ABIW_Document(correctAnwser);
                        switch (questionCur.Type_l2)
                        {
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                                CompareWFont compare = new CompareWFont();
                                if (((ComparisonResult)compare.Compare(document1, document2)).Result == ComparisonResultIndicate.equal)
                                {
                                    question.Correct = true;
                                    score++;
                                }
                                //pair.Question = question;
                                break;
                            //case 16 : case 17 : case 18 :  case 19 : case 21:
                            //    compareWp
                        }
                        anwser.Close();
                        correctAnwser.Close();
                        application.Quit();
                    }
                    catch(Exception e)
                    {

                    }                  
                        // call to CompareWFont.Compare()
                }
            }
            //exam.Score = new ScoreResult(score);
            // implement total result here
            MessageBox.Show("Score: "+score);
        }
        #endregion
    }
}