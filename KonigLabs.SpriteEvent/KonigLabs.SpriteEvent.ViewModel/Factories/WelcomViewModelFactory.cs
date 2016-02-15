using KonigLabs.SpriteEvent.CommonViewModel.Factories;
using KonigLabs.SpriteEvent.CommonViewModel.Navigator;
using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.Factories
{
    public class WelcomViewModelFactory : ViewModelBaseFactory<WelcomViewModel>
    {
        private IViewModelNavigator _navigator;
        public WelcomViewModelFactory(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        protected override WelcomViewModel GetViewModel(object param)
        {
            return new WelcomViewModel(_navigator);
        }
    }
}
