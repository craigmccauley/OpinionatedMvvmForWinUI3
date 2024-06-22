using Microsoft.Extensions.DependencyInjection;
using Microsoft.Windows.AppLifecycle;
using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using System;
using System.Threading.Tasks;

namespace MvvmApp;

internal class ApplicationService
{
    private readonly IServiceProvider serviceProvider = ApplicationSetup.BuildServiceProvider();
    private bool isInitialized = false;

    internal void Initialize()
    {
        _ = new App();

        var hooks = serviceProvider.GetService<IHooks>();
        var mainWindow = serviceProvider.GetService<IMainWindow>();
        var pageViewModelService = serviceProvider.GetService<IPageViewModelService>();
        hooks.Initialize(mainWindow, pageViewModelService);

        isInitialized = true;
    }

    internal async Task OnApplicationActivated(object sender, AppActivationArguments args)
    {
        if (!isInitialized)
        {
            throw new Exception("Application not Initialized");
        }

        var hooks = serviceProvider.GetService<IHooks>();

        await hooks.RunAsync(() =>
        {
            var vm = hooks.GetPageViewModel(Core.Infrastructure.Application.Pages.MainWindow);
            if (vm is MainWindowViewModel mainWindowViewModel)
            {
                mainWindowViewModel.SelectedView = hooks.GetPageViewModel(Core.Infrastructure.Application.Pages.NavPage);
                hooks.ActivateMainWindow();
            }
        });

        //var previousExecutionState = sender == null ? ApplicationExecutionStates.NotRunning : ApplicationExecutionStates.Running;
        //var activationArgsString = ((LaunchActivatedEventArgs)args.Data).Arguments;
        //var activationService = serviceProvider.GetService<IActivationService>();
        //await activationService.Activate(args, previousExecutionState);
    }
}