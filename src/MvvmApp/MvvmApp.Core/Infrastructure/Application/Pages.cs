using MvvmApp.Core.Features.FormPage;
using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Features.NavPage;
using MvvmApp.Core.Features.NoNavPage;
using MvvmApp.Core.Features.SettingsPage;
using MvvmApp.Core.Features.WelcomePage;
using System;

namespace MvvmApp.Core.Infrastructure.Application;

public record Page(Type ViewModelType);
public static class Pages
{
    public static Page MainWindow = new(typeof(MainWindowViewModel));
    public static Page NoNavPage = new(typeof(NoNavPageViewModel));
    public static Page NavPage = new(typeof(NavPageViewModel));
    public static Page WelcomePage = new(typeof(WelcomePageViewModel));
    public static Page FormPage = new(typeof(FormPageViewModel));
    public static Page SettingsPage = new(typeof(SettingsPageViewModel));

    public static Page[] All =
    [
        MainWindow,
        NoNavPage,
        NavPage,
        WelcomePage,
        FormPage,
        SettingsPage,
    ];
}
