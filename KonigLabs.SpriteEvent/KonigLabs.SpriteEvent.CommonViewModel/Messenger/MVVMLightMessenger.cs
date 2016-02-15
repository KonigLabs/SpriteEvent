using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.Messenger
{
    public class MvvmLightMessenger : IMessenger
    {
        public MvvmLightMessenger()
        {

        }
        public TMessage CreateMessage<TMessage>()
        {
            return Activator.CreateInstance<TMessage>();
        }

        public void Send<TMessage>(TMessage message)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(message);
        }

        public void Register<TMessage>(object recepient, Action<TMessage> callback)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register(recepient, callback);
        }

        public void Unregister<TMessage>(object recepient)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Unregister<TMessage>(recepient);
        }
    }
}
