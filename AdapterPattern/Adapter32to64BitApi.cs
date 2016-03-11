using System;

namespace Adapter_Pattern
{
    class Adapter32to64BitApi : I32BitApi
    {
        /* code behind the interface is proprietary and hidden */

        private I64BitApi m_camera = new Camera64BitApi();

        public Adapter32to64BitApi() { }

        #region adapter

        public void LowVoltage()    /* 32 bit api call */
        {
            /* adapted to 64 bit api call */
            if (m_camera.IsEnergized) m_camera.CyclePower();
        }

        public void HighVoltage()     /* 32 bit api call */
        {
            /* adapted to 64 bit api call */
            if (!m_camera.IsEnergized) m_camera.CyclePower();
        }

        public Array Background()       /* 32 bit api call */
        {
            /* adapted to 64 bit api call */
            Array img = null;
            img = m_camera.CaptureImage(true);
            return img;
        }

        public Array Foreground()       /* 32 bit api call */
        {
            /* adapted to 64 bit api call */
            Array img = null;
            img = m_camera.CaptureImage(false);
            return img;
        }

        #endregion adapter

    }
}
