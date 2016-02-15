using System.Runtime.InteropServices;

namespace KonigLabs.SpriteEvent.SDKData.Structs
{
    /// <summary>
    /// TODO - document
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ICCProfile
    {
        // TODO: find out more about this structure
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        byte[] data;
    }
}
