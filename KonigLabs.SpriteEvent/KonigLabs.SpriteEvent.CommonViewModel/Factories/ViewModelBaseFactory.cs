using KonigLabs.SpriteEvent.CommonViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.Factories
{
    public abstract class ViewModelBaseFactory<TViewModel> : IViewModelFactory where TViewModel : BaseViewModel
    {
        public virtual BaseViewModel Get(object param)
        {
            return GetViewModel(param);
        }

        protected abstract TViewModel GetViewModel(object param);
    }
}
