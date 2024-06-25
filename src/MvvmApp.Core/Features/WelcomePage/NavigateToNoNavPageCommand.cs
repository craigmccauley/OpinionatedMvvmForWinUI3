using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Core.Features.WelcomePage;
public interface INavigateToNoNavPageCommand : ICommand { }
public class NavigateToNoNavPageCommand(IHooks hooks) : CommandAsyncBase, INavigateToNoNavPageCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainWindow) is MainWindowViewModel mpvm)
        {
            await hooks.RunOnUIThreadAsync(() => mpvm.SelectedView = hooks.GetPageViewModel(Pages.NoNavPage));
        }
    }
}