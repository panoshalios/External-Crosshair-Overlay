using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NativeImports;

namespace Hacks
{
    public class Process
    {
        private string processWindowName;
        private IntPtr procHwnd;
        

        /// <summary>
        /// Creates a new instance of the Hacks.Process class.
        /// </summary>
        /// <param name="windowName">The name displayed on the top of the process window.</param>
        public Process(string windowName)
        {
            this.processWindowName = windowName; 
            procHwnd = IntPtr.Zero;
        }

        public bool IsProcessRunning()
        {
            procHwnd = Managed.FindWindow(null, processWindowName);
            if (procHwnd != IntPtr.Zero)
                return true;
            else
                return false;
        }

        public bool IsProcessInForeground()
        {
            if (procHwnd == Managed.GetForegroundWindow())
                return true;
            else
                return false;
        }

        public Point GetWindowCenter()
        {
            Point windowCenter = new Point();
            Managed.RECT windowRect = new Managed.RECT();
            Managed.GetWindowRect(procHwnd, out windowRect);

            windowCenter.X = windowRect.left + ((windowRect.right - windowRect.left) / 2);
            windowCenter.Y = windowRect.top + ((windowRect.bottom - windowRect.top) / 2);
            return windowCenter;
        }

        public static System.Diagnostics.Process[] GetRunningProcesses()
        {
             return System.Diagnostics.Process.GetProcesses();
        }
    }
}
