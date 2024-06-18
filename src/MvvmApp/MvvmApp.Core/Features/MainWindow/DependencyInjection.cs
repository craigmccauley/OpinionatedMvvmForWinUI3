using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.MainWindow;
public static class DependencyInjection
{
    public static void AddFeaturesMainWindow(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, MainWindowViewModelFactory>();
    }
}
