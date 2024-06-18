using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Windows.Input;

namespace MvvmApp.Core.Features.NoNavPage;
public interface INavigateToNavPageCommand : ICommand { }
public class NavigateToNavPageCommand(IHooks hooks) : CommandBase, INavigateToNavPageCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainWindow) is MainWindowViewModel mpvm)
        {
            mpvm.SelectedView = hooks.GetPageViewModel(Pages.NavPage);
        }
    }
}