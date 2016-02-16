using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;

namespace KonigLabs.SpriteEvent.CommonViewModels.Messenger
{
    public class ShowChildWindowMessage
    {
        public bool IsDialog { get; set; }

        public BaseViewModel Content { get; set; }
    }
}
