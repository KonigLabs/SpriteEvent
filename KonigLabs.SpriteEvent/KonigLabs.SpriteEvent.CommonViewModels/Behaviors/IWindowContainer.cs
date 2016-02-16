using System;

namespace KonigLabs.SpriteEvent.CommonViewModels.Behaviors
{
    public interface IWindowContainer
    {
        event EventHandler<ShowWindowEventArgs> ShowWindow; 
    }
}
