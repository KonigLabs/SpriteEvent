using KonigLabs.SpriteEvent.CommonViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.CommonViewModel.Factories
{
    public interface IViewModelFactory
    {
        BaseViewModel Get(object param);
    }
}
