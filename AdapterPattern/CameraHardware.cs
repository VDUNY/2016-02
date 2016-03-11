using System;

namespace Adapter_Pattern
{
    /* manufacturer firmware; not available to the developer */
    class CameraHardware
    {
        public CameraHardware()
        {
            Energize(false);
        }

        #region system state
        public void Energize(bool bTurnOnHighVoltage)
        {
            if (bTurnOnHighVoltage)
            {
                IsEnergized = true;
                Console.WriteLine("Hardware set to energized");
            }
            else
            {
                IsEnergized = false;
                Console.WriteLine("Hardware set to de-energized");
            }
        }

        public bool IsEnergized { get; set; }
        #endregion system state

        #region Image
        public void CaptureImage(bool bBackground)
        {
            Array img = null;
            if (bBackground) 
            {
                Image = Array.CreateInstance(typeof(ushort), 8);
                Console.WriteLine("Hardware capturing background");
                ImageReady = true;
            }
            else 
            {
                Image = Array.CreateInstance(typeof(ushort), 8);
                Console.WriteLine("Hardware capturing foreground");
                ImageReady = true;
            }
        }

        public bool ImageReady { get; set; }

        public Array Image { get; set; }
        #endregion
    }
}
