using System;

namespace Singleton_Pattern
{
    class SingletonPattern
    {
        static void Main(string[] args)
        {
            string status = "";

            // client can only get this one and only instance; 
            CameraHardware m_camera1 = CameraHardware.CreateCamera("eureka", "5000", "#1234");
            CameraHardware m_camera2 = CameraHardware.CreateCamera("eureka", "5000", "#1234");

            // what if we put the ops for cam1 and cam2 in their own threads?

            status = m_camera1.Acquire(false);  // is this call thread safe?
            Console.WriteLine("cam 1 acqs img: " + status);

            // what if we had multiple clients coming in from the web
            status = m_camera2.Acquire(false);
            Console.WriteLine("cam 2 acqs img: " + status);

            Console.WriteLine("<enter> to quit");
            Console.ReadLine();
        }
    }
}
