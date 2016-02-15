using System;
using System.Runtime.InteropServices;
using KonigLabs.SpriteEvent.SDKData.Miscellaneous;

namespace KonigLabs.SpriteEvent.SDKData.Structs
{
    /// <summary>
    /// TODO - document
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DirectoryItemInformation
    {
        public UInt32 Size;
        public int IsFolder;
        public UInt32 GroupID;   // K234 later
        public UInt32 Option;    // K234 later EdsEnumTransferOption

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = GlobalConstants.MAX_NAME)]
        public string FileName;
    }
}
