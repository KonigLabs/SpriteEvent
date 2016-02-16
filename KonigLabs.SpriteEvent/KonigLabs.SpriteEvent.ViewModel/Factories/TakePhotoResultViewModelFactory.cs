using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.SpriteEvent.PatternProcessing;
using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.Factories
{
    public class TakePhotoResultViewModelFactory : ViewModelBaseFactory<TakePhotoResultViewModel>
    {
        private IViewModelNavigator _navigator;
        public TakePhotoResultViewModelFactory(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        protected override TakePhotoResultViewModel GetViewModel(object param)
        {
            return new TakePhotoResultViewModel(_navigator, (byte[])param);
        }
    }
}
