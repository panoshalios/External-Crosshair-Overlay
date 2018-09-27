using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NativeImports;

namespace Hacks
{
    public partial class Hack : Form
    {
        private HackList hackList;
        private Thread hackThread;
        private Process process;
        private ExternalCrosshair crosshair;

        public Hack(Process proc)
        {
            if (proc == null)
                throw new NullReferenceException("The process had a null value");

            InitializeComponent();
            OverlayTheForm();

            hackList = new HackList();
            crosshair = new ExternalCrosshair(this.Handle, 10);

            process = proc;
            hackThread = new Thread(() => RunHackLoop());


            EnableCrosshair();
        }


        private void RunHackLoop()
        {
            while(hackList.AreHacksRunning)
            {
                Thread.Sleep(16);

                if (process.IsProcessRunning() && process.IsProcessInForeground())
                {
                    if(hackList.Crosshair)
                    {
                        //Point coordinatesToDraw = process.GetWindowCenter();
                        //coordinatesToDraw.X += 8;
                        //coordinatesToDraw.Y += 20;
                        Point coordinatesToDraw = Cursor.Position;
                        coordinatesToDraw.Y += 20;
                        coordinatesToDraw.X += 8;

                        crosshair.CoordinatesToDraw = coordinatesToDraw;
                        crosshair.DrawCrosshair();
                    }
                }
            }
        }


        public void EnableCrosshair()
        {
            hackList.Crosshair = true;
            EnableHackThread();
        }

        public void DisableCrosshair()
        {
            hackList.Crosshair = false;
        }

        public bool IsCrosshairActive()
        {
            return hackList.Crosshair;
        }

        private void EnableHackThread()
        {
            if (!hackThread.IsAlive)
                hackThread.Start();
        }

        private void OverlayTheForm()
        {
            Managed.SetWindowLong(this.Handle, Managed.GWL_STYLE, Managed.WS_VISIBLE | Managed.WS_POPUP | Managed.WS_MAXIMIZE);
            Managed.SetWindowLong(this.Handle, Managed.GWL_EXSTYLE, Managed.GetWindowLong(this.Handle, Managed.GWL_EXSTYLE) | Managed.WS_EX_LAYERED | Managed.WS_EX_TRANSPARENT);

            Managed.Margins margins;
            margins.cxLeftWidth = 0;
            margins.cxRightWidth = this.Width;
            margins.cyTopHeight = 0;
            margins.cyBottomHeight = this.Height;
            Managed.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }

        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hackList.DisableAllHacks();
            hackThread.Join();
            crosshair.Dispose();
        }
    }
}
