using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using System.Linq;
using System.Windows.Input;

namespace MvvmApp.Core.Features.NavPage;
public interface ILoadedCommand : ICommand { }
public class LoadedCommand(
    IHooks hooks) : CommandBase, ILoadedCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if (parameter is not NavPageViewModel vm
            || vm.MenuItems == null
            || !vm.MenuItems.Any())
        {
            return;
        }
        vm.MenuItems.FirstOrDefault().IsSelected = true;
        vm.SelectedView = hooks.GetPageViewModel(Pages.WelcomePage);
    }
}
