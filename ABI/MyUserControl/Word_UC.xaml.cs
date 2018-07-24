using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;

namespace ABI.MyUserControl
{
    /// <summary>
    /// Interaction logic for Word_UC.xaml
    /// </summary>
    public partial class Word_UC : UserControl
    {
        #region "API Calling"

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="strclassName">calss name</param>
        /// <param name="strWindowName">window class name</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        /// <summary>
        /// Changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWndChild">A handle to the child window</param>
        /// <param name="hWndNewParent">A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window</returns>

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// These windows are ordered according to their appearance on the screen. 
        /// The topmost window receives the highest rank and is the first window in the Z order
        /// </summary>
        /// <param name="hWnd">A handle to the window</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
        /// <param name="X">position of the left side of the window</param>
        /// <param name="Y">position of the top of the window</param>
        /// <param name="cx">width of the window</param>
        /// <param name="cy">height of the window</param>
        /// <param name="uFlags">
        /// window sizing and positioning flags.
        /// SWP_DRAWFRAME(0x20):Draws a frame (defined in the window's class description) around the window
        /// SWP_NOMOVE(0x2):Retains the current position (ignores X and Y parameters)
        /// SWP_NOZORDER(0x4):Retains the current Z order (ignores the hWndInsertAfter parameter).
        /// </param>
        /// <returns>If the function succeeds, the return value is nonzero</returns>

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        private static extern bool MoveWindow(
           int hWnd,
           int x,
           int y,
           int nWidth,
           int nHeight,
           bool bRepaint
       );
        #endregion

        Word.Application word = null;
        public Document document;
        public static int wordWnd;

        public Word_UC()
        {
            InitializeComponent();
            //PresentationSource source = PresentationSource.FromVisual(this) as HwndSource;
            
        }

        public void OpenDocument(string path)
        {
            word = new Word.Application();
            
            word.Visible = true;
            
            wordWnd = FindWindow("Opusapp", null);

            if (word != null && word.Documents != null)
            {
                document = word.Documents.Open(path);
                //word.Activate();
                document.Activate();
               
            }

            HwndSource source = (HwndSource)HwndSource.FromVisual(this);
            IntPtr hWnd = source.Handle;
            int handle = hWnd.ToInt32();

            //System.Windows.Point location = this.TranslatePoint(new System.Windows.Point(0, 0), (UIElement)VisualTreeHelper.GetParent(this));
            
            SetParent(wordWnd, handle);

            MoveWindow(wordWnd, (int) this.Margin.Left, (int) this.Margin.Top, (int)this.ActualWidth, (int) this.ActualHeight, true);
            //SetLocation();
        }

        public void SetLocation()
        {
            //System.Windows.Point location = this.TranslatePoint(new System.Windows.Point(0, 0), (UIElement)VisualTreeHelper.GetParent(this));
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MoveWindow(wordWnd, (int)this.Margin.Left, (int)this.Margin.Top, (int)this.ActualWidth, (int)this.ActualHeight, true);
        }
    }
}
