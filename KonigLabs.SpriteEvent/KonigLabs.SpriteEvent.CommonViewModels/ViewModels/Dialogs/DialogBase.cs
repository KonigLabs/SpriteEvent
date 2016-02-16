using System;
using KonigLabs.SpriteEvent.CommonViewModels.Behaviors;

namespace KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Dialogs
{
    public abstract class DialogBase : BaseViewModel, ICloseable
    {
        public event EventHandler<bool> StateChanged;
        public event Action<WindowState> RequestWindowVisibilityChanged;
        public void OnClose()
        {
            
        }

        protected void Close()
        {
            var handler = RequestWindowVisibilityChanged;
            if (handler != null)
                handler(WindowState.Closed);
        }

        public abstract string Title { get; }
    }
}