using System.Runtime.InteropServices;
using KonigLabs.SpriteEvent.SDKData.Enums;

namespace KonigLabs.SpriteEvent.SDKData.Structs
{
    /// <summary>
    /// Indicates the white balance bracket amount.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WhiteBalanceBracket
    {
        BracketMode BracketMode;
        WhiteBalanceShift WhiteBalanceShift;
    }
}
