using System;
using System.Threading;

namespace Adapter_Pattern
{
    class Camera64BitApi : I64BitApi
    {
        /* provided by manufacturer; not available to the developer */

        private CameraHardware m_camera = new CameraHardware();

        #region I64BitApi

        public bool IsEnergized { get { return m_camera.IsEnergized; } }

        public void CyclePower()
        {
            if (m_camera.IsEnergized)
            {
                PowerDown();
                Console.WriteLine("64 bit api powered down");
            }
            else
            {
                PowerUp();
                Console.WriteLine("64 bit api powered up");
            }
        }

        public Array CaptureImage(bool bTakeBackground)
        {
            Array img = null;
            Console.WriteLine("64 bit api capturing data");
            m_camera.CaptureImage(true);
            if (m_camera.ImageReady) img = m_camera.Image;
            return img;
        }

        #endregion I64BitApi

        private void PowerDown() { m_camera.Energize(false); }

        private void PowerUp() { m_camera.Energize(true); }

    }
}
