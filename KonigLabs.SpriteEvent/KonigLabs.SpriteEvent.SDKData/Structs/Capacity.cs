using System.Runtime.InteropServices;

namespace KonigLabs.SpriteEvent.SDKData.Structs
{
    /// <summary>
    /// TODO - document
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct Capacity
    {
        public int NumberOfFreeClusters;
        public int BytesPerSector;
        public int Reset;
    }
}
