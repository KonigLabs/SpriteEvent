using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Validation;

namespace KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Dialogs
{
    public abstract class ResultBaseViewModel : ValidateableViewModel
    {
        public abstract bool CanConfirm { get; }

        public abstract string Title { get; }
    }
}
