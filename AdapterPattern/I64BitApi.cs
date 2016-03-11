using System;

namespace Adapter_Pattern
{
    interface I64BitApi
    {
        bool IsEnergized { get; }

        void CyclePower();

        Array CaptureImage(bool bTakeBackground);

    }
}
