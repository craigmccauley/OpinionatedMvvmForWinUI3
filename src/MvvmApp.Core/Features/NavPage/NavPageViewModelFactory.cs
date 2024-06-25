using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NavPage;

public class NavPageViewModelFactory(ISelectionChangedCommand selectionChangedCommand) 
    : PageViewModelFactoryBase<NavPageViewModel>
{
    public override NavPageViewModel Invoke()
    {
        var vm = new NavPageViewModel
        {
            MenuItems = [],
            SelectionChangedCommand = selectionChangedCommand
        };

        var firstMenuItem = new MenuItem
        {
            Content = "Home",
            Glyph = "Home",
            NavDestination = Pages.WelcomePage,
            Parent = vm,
        };

        vm.MenuItems.Add(firstMenuItem);

        vm.MenuItems.Add(new()
        {
            Content = "Form",
            Glyph = "Page",
            NavDestination = Pages.FormPage,
            Parent = vm,
        });

        vm.SelectedMenuItem = firstMenuItem;

        return vm;
    }
}