using System;

namespace Adapter_Pattern
{
    class AdapterPattern
    {
        static void Main(string[] args)
        {
            Array img = null;
            // 32-bit code
            /* code behind the interface is proprietary and hidden */
            Console.WriteLine("Driver uses 32 bit api interface");
            I32BitApi m_camera32Bit = new Camera32BitApi();
            m_camera32Bit.HighVoltage();
            img = m_camera32Bit.Background();
            Console.WriteLine();

            // 64-bit code
            /* code behind the interface is proprietary and hidden */
            Console.WriteLine("Driver uses 64 bit api interface");
            I64BitApi m_camera64Bit = new Camera64BitApi();
            if (m_camera64Bit.IsEnergized) { } else { m_camera64Bit.CyclePower(); }
            img = m_camera64Bit.CaptureImage(true);
            Console.WriteLine();

            // 32-bit code to 64-bit api
            Console.WriteLine("Driver uses 32 bit api interface to manage 64 bit api ");
            I32BitApi m_camera32To64Bit = new Adapter32to64BitApi();
            m_camera32To64Bit.HighVoltage();
            img = m_camera32To64Bit.Background();
            Console.WriteLine();

            Console.WriteLine("<enter> to quit");
            Console.ReadLine();

        }
    }


}
