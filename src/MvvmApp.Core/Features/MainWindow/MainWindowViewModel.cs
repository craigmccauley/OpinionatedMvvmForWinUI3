using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.MainWindow;
public partial class MainWindowViewModel : ObservableObject, IPageViewModel
{
    [ObservableProperty]
    private IPageViewModel selectedView;
}
