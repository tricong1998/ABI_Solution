// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:28 PM 2018/7/15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ABI
{
    public class OpenDocument
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0x4;
        const int SWP_SHOWWINDOW = 0x0040;

        /// <summary>
        /// to open new document
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bound"></param>
        public void Open(string filePath, Rect bound)
        {
            var psi = new System.Diagnostics.ProcessStartInfo(filePath);
            var process = System.Diagnostics.Process.Start(psi);
            process.WaitForInputIdle();
            System.Threading.Thread.Sleep(2000);
            IntPtr windowHandle = process.MainWindowHandle;

            MoveWindow(windowHandle, (int)bound.Left, (int)bound.Top, (int)bound.Width, (int)bound.Height, false);
            int i = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
            if (i != 0)
               logger.Error("An error occured when try to open document. Error code: " + i);
        }
    }
}
