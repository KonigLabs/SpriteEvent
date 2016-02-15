using System;
using System.Runtime.InteropServices;
using KonigLabs.SpriteEvent.SDKData.Miscellaneous;

namespace KonigLabs.SpriteEvent.SDKData.Structs
{
    /// <summary>
    /// TODO - document
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInformation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = GlobalConstants.MAX_NAME)]
        public string PortName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = GlobalConstants.MAX_NAME)]
        public string DeviceDescription;

        public UInt32 DeviceSubType;

        public UInt32 Reserved;
    }
}
