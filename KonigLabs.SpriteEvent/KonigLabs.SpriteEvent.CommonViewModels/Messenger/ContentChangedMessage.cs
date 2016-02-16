using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;

namespace KonigLabs.SpriteEvent.CommonViewModels.Messenger
{
    public class ContentChangedMessage
    {
        public ContentChangedMessage()
        {
        }

        public object Parameter { get; set; }

        public BaseViewModel Content { get; set; }
    }
}
