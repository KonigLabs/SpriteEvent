
using KonigLabs.SpriteEvent.CommonViewModels.Messenger;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.SpriteEvent.PatternProcessing.ImageProcessors;
using KonigLabs.SpriteEvent.ViewModel.Factories;
using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using System.Linq;

namespace KonigLabs.SpriteEvent.ViewModel.Ninject
{
    public class NinjectMainModule: NinjectModule
    {
        public override void Load()
        {
            
            Bind<MainViewModel>().ToSelf();
            Bind<WelcomViewModel>().ToSelf();
            Bind<CompositionModelProcessorFactory>().ToSelf();
            Bind<TakePhotoViewModelFactory>().ToSelf();
            Bind<WelcomViewModelFactory>().ToSelf();
            Bind<TakePhotoResultViewModelFactory>().ToSelf();
            Bind<IViewModelNavigator>().To<ViewModelNavigator>()
                .WithConstructorArgument(typeof(IChildrenViewModelsFactory),
                    x => new ChildrenViewModelsFactory(Enumerable.Empty<IViewModelFactory>()));
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<MainViewModel>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<WelcomViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<WelcomViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<TakePhotoViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<TakePhotoViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<TakePhotoResultViewModelFactory>()
                };

                return new ChildrenViewModelsFactory(children);
            });
        }
    }
}
