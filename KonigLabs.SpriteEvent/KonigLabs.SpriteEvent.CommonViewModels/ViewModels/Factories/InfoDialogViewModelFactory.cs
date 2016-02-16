using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Dialogs;

namespace KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories
{
    public class InfoDialogViewModelFactory : ViewModelBaseFactory<InfoDialogViewModel>
    {
        protected override InfoDialogViewModel GetViewModel(object param)
        {
            return new InfoDialogViewModel(param.ToString());
        }
    }
}