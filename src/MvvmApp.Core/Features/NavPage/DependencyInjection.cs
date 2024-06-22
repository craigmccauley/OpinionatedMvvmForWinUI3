using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NavPage;
public static class DependencyInjection
{
    public static void AddFeaturesNavPage<TSelectionChangedCommand>(this IServiceCollection services) where TSelectionChangedCommand : class, ISelectionChangedCommand
    {
        services.AddSingleton<IPageViewModelFactory, NavPageViewModelFactory>();
        services.AddSingleton<ILoadedCommand, LoadedCommand>();
        services.AddSingleton<ISelectionChangedCommand, TSelectionChangedCommand>();
        services.AddSingleton<IMenuItemIsSelectedChangedService, MenuItemIsSelectedChangedService>();
    }
}
