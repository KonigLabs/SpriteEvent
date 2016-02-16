using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonigLabs.SpriteEvent.Common.Helpers;
using KonigLabs.SpriteEvent.CommonViewModels.Messenger;
using KonigLabs.SpriteEvent.CommonViewModels.Services;
using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Navigation;
using Ninject.Modules;

namespace KonigLabs.SpriteEvent.CommonViewModels.Ninject
{
    public class NinjectBaseModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IMappingEngine>()
            //    .ToMethod(x => MappingEngineConfigurator.CreateEngine(new BasicProfile()));

            Bind<MessageFactory>().ToSelf();
            Bind<IMessenger>().To<MvvmLightMessenger>().InSingletonScope();
            Bind<IHashBuilder>().To<HashBuilder>();
            Bind<ViewModelStorage>().ToSelf().InSingletonScope();
            Bind<IDialogService>().To<DialogService>();
        }
    }
}
