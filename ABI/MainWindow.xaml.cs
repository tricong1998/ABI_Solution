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
            System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(
                new System.Windows.Interop.WindowInteropHelper(this).Handle);
            this.Left = 0;
            this.Width = screen.Bounds.Width;
            this.Top = screen.Bounds.Height - this.Height;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Activate();
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // submit answer here
        }

        private void question_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _new = e.AddedItems[0] as QuestionVisual;
            web_question.NavigateToString(UTF8_HEADER + _new.Question.HtmlContent);

            // update ui here
        }
    }
}
