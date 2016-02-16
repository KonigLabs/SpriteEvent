using KonigLabs.SpriteEvent.CommonViewModels.Ninject;
using KonigLabs.SpriteEvent.ViewModel.Ninject;
using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using Ninject;
using System.Windows;

namespace KonigLabs.SpriteEvent.View
{
       
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            InitApp();
        }

        public void InitApp()
        {
            //инициализация Ninject
            var kernel = NinjectBootstrapper.GetKernel(new CommonViewModels.Ninject.NinjectBaseModule(),new NinjectMainModule());
            _mainViewModel = kernel.Get<MainViewModel>();
            MainWindow = new MainWindow() { DataContext = _mainViewModel };
            MainWindow.Closed += (s, e) =>
            {
                _mainViewModel.Dispose();
            };
            MainWindow.Show();
        }
    }
}
