using System;

namespace KonigLabs.SpriteEvent.SDKData.Events
{
    public abstract class CameraEventBase : EventArgs
    {
        public abstract string Message { get; }

        public abstract CameraEventType EventType { get; }
    }
}
