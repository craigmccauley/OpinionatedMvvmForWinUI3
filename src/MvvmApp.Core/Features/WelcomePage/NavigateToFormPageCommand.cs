using MvvmApp.Core.Features.NavPage;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Linq;
using System.Windows.Input;

namespace MvvmApp.Core.Features.WelcomePage;
public interface INavigateToFormPageCommand : ICommand { }
public class NavigateToFormPageCommand(
    IHooks hooks) : CommandBase, INavigateToFormPageCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        var navViewModel = hooks.GetPageViewModel(Pages.NavPage) as NavPageViewModel;
        var menuItemToSelect = navViewModel.MenuItems.FirstOrDefault(mi => mi.NavDestination == Pages.FormPage);
        if (menuItemToSelect == null)
        {
            return;
        }
        hooks.RunAsync(() => navViewModel.SelectedMenuItem = menuItemToSelect);
    }
}
