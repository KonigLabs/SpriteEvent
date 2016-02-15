using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.ViewModels
{
    public class BaseViewModel : ViewModelBase, IDisposable
    {
        static BaseViewModel()
        {
            DispatcherHelper.Initialize();
        }
        public virtual void Dispose()
        {
        }

        public virtual void Initialize()
        {

        }

        protected virtual void UiInvoke(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
    }
}
