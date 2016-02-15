using KonigLabs.SpriteEvent.CommonViewModel.Factories;
using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.Factories
{
    public class TakePhotoViewModelFactory : ViewModelBaseFactory<TakePhotoViewModel>
    {
        protected override TakePhotoViewModel GetViewModel(object param)
        {
            return new TakePhotoViewModel();
        }
    }
}
