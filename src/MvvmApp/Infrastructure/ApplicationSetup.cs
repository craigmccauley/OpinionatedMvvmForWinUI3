using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Core.Features.FormPage;
using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Features.NavPage;
using MvvmApp.Core.Features.NoNavPage;
using MvvmApp.Core.Features.SettingsPage;
using MvvmApp.Core.Features.WelcomePage;
using MvvmApp.Core.Infrastructure.Application;
using System;

namespace MvvmApp
{
    public static class ApplicationSetup
    {
        public static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IHooks, Hooks>();
            services.AddSingleton<IMainWindow, MainWindow>();
            services.AddSingleton<IPageViewModelService, PageViewModelService>();
            services.AddSingleton<IPageFactory, PageFactory>();

            services.AddFeaturesFormPage();
            services.AddFeaturesMainWindow();
            services.AddFeaturesNavPage<SelectionChangedCommand>();
            services.AddFeaturesNoNavPage();
            services.AddFeaturesSettingsPage();
            services.AddFeaturesWelcomePage();

            return services.BuildServiceProvider();
        }
    }
}
