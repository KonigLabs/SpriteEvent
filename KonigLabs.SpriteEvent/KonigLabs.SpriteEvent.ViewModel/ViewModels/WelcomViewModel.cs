﻿using GalaSoft.MvvmLight.Command;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;


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
