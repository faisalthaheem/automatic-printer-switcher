using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PrinterSwitcher
{
    public class PSWindows
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int SendMessage(
              IntPtr hWnd,      // handle to destination window
              uint Msg,       // message
              long wParam,  // first message parameter
              long lParam   // second message parameter
              );

        //process name = windowname, meta
        public PSProcessCollection mProcesses = new PSProcessCollection();

        public bool scan()
        {
            try
            {
                mProcesses.Clear();

                Process[] processes = Process.GetProcesses();

                //Pre create the classes
                //we only consider processes with a window
                foreach (Process process in processes)
                {
                    if (!mProcesses.ContainsKey(process.ProcessName) && !string.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        mProcesses[process.ProcessName]
                                = new PSProcess(process.ProcessName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        
    }
}
