namespace KonigLabs.SpriteEvent.CommonViewModels.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        BaseViewModel Get(object param);
    }
}