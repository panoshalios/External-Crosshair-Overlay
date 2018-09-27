using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Hacks
{
    public class HackList
    {
        public delegate void HacksEnableDisableArgs();

        /// <summary>
        /// Occurs when all the hacks are disabled.
        /// </summary>
        public event HacksEnableDisableArgs HacksDisabled;
        
        /// <summary>
        /// Occurs when all the hacks are enabled.
        /// </summary>
        public event HacksEnableDisableArgs HacksEnabled;

        public bool AreHacksRunning { get; private set; }

        private bool crosshair;
        public bool Crosshair
        {
            get
            {
                return crosshair;
            }
            set
            {
                crosshair = value;
                if (value == true)
                    AreHacksRunning = true;

                CheckForHackStatuses();
            }
        }

        private bool esp;
        public bool Esp
        {
            get
            {
                return esp;
            }
            set
            {
                esp = value;
                if (value == true)
                    AreHacksRunning = true;
                CheckForHackStatuses();
            }
        }

        private bool aimbot;
        public bool Aimbot
        {
            get
            {
                return aimbot;
            }
            set
            {
                aimbot = value;
                if (value == true)
                    AreHacksRunning = true;
                CheckForHackStatuses();
            }
        }

        private bool triggerbot;
        public bool Triggerbot
        {
            get
            {
                return triggerbot;
            }
            set
            {
                triggerbot = value;
                if (value == true)
                    AreHacksRunning = true;
                CheckForHackStatuses();
            }
        }

        private bool menu;
        public bool Menu
        {
            get
            {
                return menu;
            }
            set
            {
                menu = value;
                if (value == true)
                    AreHacksRunning = true;
                CheckForHackStatuses();
            }
        }


        public HackList()
        {
            DisableAllHacks();
        }

        public void DisableAllHacks()
        {
            AreHacksRunning = false;
            Crosshair = false;
            Esp = false;
            Aimbot = false;
            Triggerbot = false;
            Menu = false;
        }
        
        private void CheckForHackStatuses()
        {
            if (Crosshair && Esp && Aimbot && Triggerbot && Menu)
            {
                RaiseHacksEnabledEvent();
            }
            else if (!Crosshair && !Esp && !Aimbot && !Triggerbot && !Menu)
            {
                AreHacksRunning = false;
                RaiseHacksDisableEvent();
            }
                
        }

        private void RaiseHacksEnabledEvent()
        {
            if(HacksEnabled != null)
            {
                HacksEnabled();
            }
        }

        private void RaiseHacksDisableEvent()
        {
            if(HacksDisabled != null)
            {
                HacksDisabled();
            }
        }
    }
}
