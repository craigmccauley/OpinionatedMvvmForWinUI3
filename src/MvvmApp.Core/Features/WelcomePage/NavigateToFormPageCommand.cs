using MvvmApp.Core.Features.NavPage;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Core.Features.WelcomePage;
public interface INavigateToFormPageCommand : ICommand { }
public class NavigateToFormPageCommand(
    IHooks hooks) : CommandAsyncBase, INavigateToFormPageCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        var navPageViewModel = hooks.GetPageViewModel(Pages.NavPage) as NavPageViewModel;
        var menuItemToSelect = navPageViewModel.MenuItems.FirstOrDefault(mi => mi.NavDestination == Pages.FormPage);
        if (menuItemToSelect == null)
        {
            return;
        }
        await hooks.RunOnUIThreadAsync(() => 
        { 
            navPageViewModel.SelectedMenuItem = menuItemToSelect; 
        });
    }
}
