using KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Dialogs;

namespace KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories
{
    public class ConfirmDialogViewModelFactory : ViewModelBaseFactory<ConfirmDialogViewModel>
    {
        protected override ConfirmDialogViewModel GetViewModel(object param)
        {
            return new ConfirmDialogViewModel(param.ToString());
        }
    }
}