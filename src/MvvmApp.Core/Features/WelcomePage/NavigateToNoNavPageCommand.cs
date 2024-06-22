using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Windows.Input;

namespace MvvmApp.Core.Features.WelcomePage;
public interface INavigateToNoNavPageCommand : ICommand { }
public class NavigateToNoNavPageCommand(IHooks hooks) : CommandBase, INavigateToNoNavPageCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainWindow) is MainWindowViewModel mpvm)
        {
            mpvm.SelectedView = hooks.GetPageViewModel(Pages.NoNavPage);
        }
    }
}