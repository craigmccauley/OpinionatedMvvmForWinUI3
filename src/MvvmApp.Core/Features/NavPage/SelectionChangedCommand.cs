using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using MvvmApp.Features.NavPage;
using System.Windows.Input;

namespace MvvmApp.Core.Features.NavPage;
public interface ISelectionChangedCommand : ICommand { }
public class SelectionChangedCommand(
    IHooks hooks,
    INavigationViewSelectionChangedEventArgsToNavigationArgsMap map)
    : CommandBase, ISelectionChangedCommand
{
    protected override async void ExecuteCommand(object parameter)
    {
        var args = map.Map(parameter);
        if(args == null)
        {
            return;
        }

        await hooks.RunAsync(() =>
        {
            args.NavPageViewModel.SelectedView = hooks.GetPageViewModel(args.SelectedPage);
        });
    }
}
