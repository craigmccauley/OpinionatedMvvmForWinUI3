using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;
using MvvmApp.Features.NavPage;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Core.Features.NavPage;
public interface ISelectionChangedCommand : ICommand { }
public class SelectionChangedCommand(
    IHooks hooks,
    INavigationViewSelectionChangedEventArgsToNavigationArgsMap map)
    : CommandAsyncBase, ISelectionChangedCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        var args = map.Map(parameter);
        if (args == null)
        {
            return;
        }

        await hooks.RunOnUIThreadAsync(() =>
        {
            args.NavPageViewModel.SelectedView = hooks.GetPageViewModel(args.SelectedPage);
        });
    }
}
