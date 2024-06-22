using CommunityToolkit.WinUI;
using Microsoft.UI.Xaml;
using MvvmApp.Core.Features.MainWindow;
using MvvmApp.Core.Infrastructure.Application;
using System;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MvvmApp;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window, IMainWindow
{
    public event EventHandler MainWindowClosed;
    public MainWindowViewModel ViewModel { get; }

    public MainWindow(
        IPageViewModelService pageViewModelService)
    {
        this.InitializeComponent();

        Closed += (sender, args) => MainWindowClosed?.Invoke(sender, EventArgs.Empty);
        
        ViewModel = (MainWindowViewModel)pageViewModelService.GetPageViewModel(MvvmApp.Core.Infrastructure.Application.Pages.MainWindow);
    }

    public async Task DispatcherQueueEnqueueAsync(Action action)
    {
        await DispatcherQueue.EnqueueAsync(() => action());
    }
}
