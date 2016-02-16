using System;

namespace KonigLabs.SpriteEvent.CommonViewModels.Messenger
{
    public class MessageFactory
    {
        public TMessage CreateMessage<TMessage>()
        {
            return Activator.CreateInstance<TMessage>();
        }
    }
}
