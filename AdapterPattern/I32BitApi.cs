using System;

namespace Adapter_Pattern
{
    interface I32BitApi
    {
        void LowVoltage();
        void HighVoltage();
        Array Background();
        Array Foreground();

    }
}
