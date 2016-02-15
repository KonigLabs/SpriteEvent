using GalaSoft.MvvmLight.Command;
using KonigLabs.SpriteEvent.CommonViewModel.Navigator;
using KonigLabs.SpriteEvent.CommonViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.ViewModels
{
    public class WelcomViewModel:BaseViewModel
    {
        private IViewModelNavigator _navigator;
        public WelcomViewModel(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        private RelayCommand _startCommand;
        public RelayCommand StartCommand
        {
            get {
                return _startCommand ?? (_startCommand = new RelayCommand(OnStart));
                    }
        }
        private void OnStart()
        {
            _navigator.NavigateForward<TakePhotoViewModel>(this, null);
        }
    }
}
