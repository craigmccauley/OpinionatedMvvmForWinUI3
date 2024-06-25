using Microsoft.UI.Xaml.Controls;
using MvvmApp.Core.Features.NavPage;

namespace MvvmApp.Features.NavPage;
public class NavigationViewSelectionChangedEventArgsToNavigationArgsMap : INavigationViewSelectionChangedEventArgsToNavigationArgsMap
{
    public NavigationArgs Map(object src)
    {
        if (src is not NavigationViewSelectionChangedEventArgs args)
        {
            return null;
        }

        if (args.IsSettingsSelected)
        {
            return new NavigationArgs
            {
                SelectedPage = Core.Infrastructure.Application.Pages.SettingsPage,
                NavPageViewModel = (args.SelectedItem as NavigationViewItem).DataContext as NavPageViewModel
            };
        }
        else if (args.SelectedItem is MenuItem menuItem)
        {
            return new NavigationArgs
            {
                SelectedPage = menuItem.NavDestination,
                NavPageViewModel = menuItem.Parent
            };
        }

        return null;
    }
}
