using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NavPage;

public class NavPageViewModelFactory(
    ILoadedCommand loadedCommand,
    ISelectionChangedCommand selectionChangedCommand,
    IMenuItemIsSelectedChangedService menuItemIsSelectedChangedService) : PageViewModelFactoryBase<NavPageViewModel>
{
    public override NavPageViewModel Invoke()
    {
        var vm = new NavPageViewModel
        {
            MenuItems = [],
            LoadedCommand = loadedCommand,
            SelectionChangedCommand = selectionChangedCommand,
        };
        vm.MenuItems.Add(new()
        {
            Content = "Home",
            Glyph = "Home",
            NavDestination = Pages.WelcomePage,
            IsSelected = true,
            Parent = vm,
        });

        vm.MenuItems.Add(new()
        {
            Content = "Form",
            Glyph = "Page",
            NavDestination = Pages.FormPage,
            Parent = vm,
        });

        foreach (var item in vm.MenuItems)
        {
            item.PropertyChanged += menuItemIsSelectedChangedService.HandleIsSelectedChanged;
        }

        return vm;
    }
}