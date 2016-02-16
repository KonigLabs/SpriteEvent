using GalaSoft.MvvmLight.Command;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.SpriteEvent.PatternProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KonigLabs.SpriteEvent.ViewModel.ViewModels
{
    /// <summary>
    /// VM полученной фотографии
    /// </summary>
    public class TakePhotoResultViewModel: BaseViewModel
    {
        IViewModelNavigator _navigator;
        
        public TakePhotoResultViewModel(IViewModelNavigator navigator, byte[] photoResult)
        {
            _photoResult = photoResult;
            _navigator = navigator;
        }

        #region Комманды
        private RelayCommand _nextCommnad;
        /// <summary>
        /// Продолжить
        /// </summary>
        public RelayCommand NextCommnad
        {
            get { return _nextCommnad ?? (_nextCommnad = new RelayCommand(OnNext)); }
        }

        private void OnNext() {

        }
        private RelayCommand _repeatCommand;
        /// <summary>
        /// Повторить фотографию
        /// </summary>
        public RelayCommand RepeatCommand
        {
            get { return _repeatCommand ?? (_repeatCommand = new RelayCommand(OnRepeat)); }
        }

        private void OnRepeat()
        {
            _navigator.NavigateBack(this);
        }
        #endregion

        /// <summary>
        /// Фотографиия
        /// </summary>
        public byte[] Photo
        {
            get
            {
                return _photoResult;
            }
        }
        byte[] _photoResult;

    }
}
