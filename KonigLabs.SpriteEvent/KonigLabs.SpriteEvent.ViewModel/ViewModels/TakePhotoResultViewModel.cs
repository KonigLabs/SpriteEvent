using GalaSoft.MvvmLight.Command;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using System.Drawing;
using System.IO;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
using KonigLabs.SpriteEvent.Common.Extensions;

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
                using (var ms = new MemoryStream(_photoResult))
                {
                    return GetCartoonBwPhoto(new Bitmap(ms)).ToBytes();
                }
                    
            }
        }
        byte[] _photoResult;


        public static Bitmap GetCartoonBwPhoto(Bitmap source)
        {
            var result = source.CartoonFilter(3, 25, 15);
            using (var stream = new MemoryStream())
            {
                result.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                result = new Bitmap(MakeBlackWhite(stream));
            }
            return result;
        }

        private static MemoryStream MakeBlackWhite(MemoryStream inStream)
        {
            var outStream = new MemoryStream();
            // Initialize the ImageFactory using the overload to preserve EXIF metadata.
            using (var imageFactory = new ImageFactory(preserveExifData: true))
            {
                // Load, resize, set the format and quality and save an image.
                imageFactory.Load(inStream.ToArray())
                    .Filter(MatrixFilters.BlackWhite)
                    .Save(outStream);
            }
            return outStream;
        }
    }
}
