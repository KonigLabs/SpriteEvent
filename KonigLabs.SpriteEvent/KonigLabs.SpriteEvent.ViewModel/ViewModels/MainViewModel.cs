
using KonigLabs.SpriteEvent.CommonViewModels.Behaviors;
using KonigLabs.SpriteEvent.CommonViewModels.Messenger;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel, IWindowContainer
    {
        private IViewModelNavigator _navigator;
        private IMessenger _messenger;
        public MainViewModel(IViewModelNavigator navigator, IMessenger messenger)
        {
            messenger.Register<ContentChangedMessage>(this, OnContentChanged);
            _messenger = messenger;
            _navigator = navigator;
            _navigator.NavigateForward<WelcomViewModel>(null);
        }
        private BaseViewModel _currentContent;

        public event EventHandler<ShowWindowEventArgs> ShowWindow;

        public BaseViewModel CurrentContent
        {
            get { return _currentContent; }
            set
            {
                _currentContent = value;
                RaisePropertyChanged();
            }
        }

        private void OnContentChanged(ContentChangedMessage message)
        {
            if (CurrentContent != null)
                CurrentContent.Dispose();

            CurrentContent = message.Content;
            if (CurrentContent != null)
                CurrentContent.Initialize();
        }
    }
}
