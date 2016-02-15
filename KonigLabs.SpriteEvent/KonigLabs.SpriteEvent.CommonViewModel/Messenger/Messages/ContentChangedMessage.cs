using KonigLabs.SpriteEvent.CommonViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.Messenger.Messages
{
    public class ContentChangedMessage
    {
        public object Parameter { get; set; }

        public BaseViewModel Content { get; set; }
    }
}
