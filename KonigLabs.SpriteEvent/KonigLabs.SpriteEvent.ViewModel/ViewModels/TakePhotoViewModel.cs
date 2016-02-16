using KonigLabs.SpriteEvent.CommonViewModel.ViewModels;
using System.Drawing;
using System.IO;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
using KonigLabs.SpriteEvent.Common.Extensions;

namespace KonigLabs.SpriteEvent.ViewModel.ViewModels
{
    public class TakePhotoViewModel:BaseViewModel
    {
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

        private static MemoryStream MakeBlackWhite(Stream inStream)
        {
            var outStream = new MemoryStream();
            // Initialize the ImageFactory using the overload to preserve EXIF metadata.
            using (var imageFactory = new ImageFactory(preserveExifData: true))
            {
                // Load, resize, set the format and quality and save an image.
                imageFactory.Load(inStream)
                    .Filter(MatrixFilters.BlackWhite)
                    .Save(outStream);
            }
            return outStream;
        }
    }
}
