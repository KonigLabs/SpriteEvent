
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.SpriteEvent.PatternProcessing.ImageProcessors;
using KonigLabs.SpriteEvent.ViewModel.Providers;
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
        IViewModelNavigator _navigator;
        CompositionModelProcessorFactory _imageProcessor;
        SettingsProvider _settingsProvider;
        public TakePhotoViewModelFactory(IViewModelNavigator navigator, CompositionModelProcessorFactory processor, SettingsProvider settingsProvider)
        {
            _navigator = navigator;
            _imageProcessor = processor;
            _settingsProvider = settingsProvider;
        }
        protected override TakePhotoViewModel GetViewModel(object param)
        {

            return new TakePhotoViewModel(_navigator, _imageProcessor.Create(new Entities.Template { Images = new List<Entities.TemplateImage>() }), _settingsProvider);
        }
    }
}
