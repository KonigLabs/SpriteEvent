using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.Messenger
{
    public interface IMessenger
    {
        TMessage CreateMessage<TMessage>();

        void Send<TMessage>(TMessage message);

        void Register<TMessage>(object recepient, Action<TMessage> callback);

        void Unregister<TMessage>(object recepient);
    }
}
