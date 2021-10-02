using System;
using System.Runtime.InteropServices;

namespace HKS.Core.Hvdk
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetFeatureKeyboard
    {
        public Byte ReportID;
        public Byte CommandCode;
        public uint Timeout;
        public Byte Modifier;
        public Byte Padding;
        public Byte Key0;
        public Byte Key1;
        public Byte Key2;
        public Byte Key3;
        public Byte Key4;
        public Byte Key5;
    }
}
