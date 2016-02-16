using System.Threading.Tasks;
using System.Windows.Input;

namespace KonigLabs.SpriteEvent.CommonViewModels.Async
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
