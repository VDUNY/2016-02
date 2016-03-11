using System;
using System.Threading;     // Thread.Sleep()

namespace Singleton_Pattern
{

    class CameraHardware
    {

        // field initialization:  no ability for try-catch
        //      private ushort m_flag = 0xffff  /* no compiler complaint, actually -1 */
        //      private ushort m_flag = -1      /* compiler complaint */

        static CameraHardware m_camera = null;
        static object objLock = new object();

        // auto-implemented property
        public string IpAddr { get; set; }  // available outside of class for good or bad

        private string m_port = "";         // not avail outside of class
        private string m_serialNumber = "";


        // where to initialize
        // 
        private CameraHardware() { }

        // constructor initialization
        private CameraHardware(string ipAddr, string port, string serialNumber) 
        {
            try
            {
                IpAddr = ipAddr;
                m_port = port;
                m_serialNumber = serialNumber;
            }
            catch (Exception) { }
        }

        static public CameraHardware CreateCamera(string ipAddr, string port, string serialNumber) 
        { 
            lock (objLock)  // multi-thread protection; need atomic operation here
            {
                if (m_camera == null) 
                {
                    Console.WriteLine(" creating camera " + ipAddr);
                    m_camera = new CameraHardware(ipAddr, port, serialNumber); 
                }
            }
            return m_camera;
        }

        // in the real world, multiple threads might be asking for image data.
        public string Acquire(bool keepShutterClosed) 
        { 
            lock (objLock)
            {
                Thread.Sleep(2000); return "image acquired";
            }
        }

    }
}
