using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Core.Features.NoNavPage;
public interface INavigateToNavPageCommand : ICommand { }
public class NavigateToNavPageCommand(IHooks hooks) : CommandAsyncBase, INavigateToNavPageCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainWindow) is MainWindowViewModel mpvm)
        {
            await hooks.RunOnUIThreadAsync(() => mpvm.SelectedView = hooks.GetPageViewModel(Pages.NavPage));
        }
    }
}