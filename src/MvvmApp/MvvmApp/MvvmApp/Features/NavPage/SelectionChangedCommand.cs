using Microsoft.UI.Xaml.Controls;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NavPage;
public class SelectionChangedCommand(
    IHooks hooks) : CommandBase, ISelectionChangedCommand
{
    protected override async void ExecuteCommand(object parameter)
    {
        if (parameter is not NavigationViewSelectionChangedEventArgs args
            || !args.IsSettingsSelected)
        {
            return;
        }

        var viewModel = (NavPageViewModel)((NavigationViewItem)args.SelectedItem).DataContext;
        await hooks.RunAsync(() =>
        {
            viewModel.SelectedView = hooks.GetPageViewModel(MvvmApp.Core.Infrastructure.Application.Pages.SettingsPage);
        });
    }
}
