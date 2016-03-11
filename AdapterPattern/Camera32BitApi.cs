using System;
using System.Threading;

namespace Adapter_Pattern
{
    class Camera32BitApi : I32BitApi
    {
        /* provided by manufacturer; not available to the developer */

        CameraHardware m_camera = new CameraHardware();

        #region I32BitApi

        public void LowVoltage()
        {
            m_camera.Energize(false);
            Console.WriteLine("32 bit Low voltage set");
        }

        public void HighVoltage()
        {
            m_camera.Energize(true);
            Console.WriteLine("32 bit High voltage set");
        }

        public Array Background()
        {
            Array img = null;
            m_camera.CaptureImage(true);
            Thread.Sleep(1000);
            if (m_camera.ImageReady) { img = m_camera.Image; }
            Console.WriteLine("32 bit Background");
            return img;
        }

        public Array Foreground()
        {
            Array img = null;
            m_camera.CaptureImage(false);
            Thread.Sleep(1000);
            if (m_camera.ImageReady) { img = m_camera.Image; }
            Console.WriteLine("32 bit Foreground");
            return img;
        }

        #endregion I32BitApi
    }
}
