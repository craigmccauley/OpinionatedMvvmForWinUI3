using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Core.Infrastructure.Common;
using System.Collections.ObjectModel;

namespace MvvmApp.Core.Features.NavPage;
public partial class NavPageViewModel : ObservableObject, IPageViewModel
{
    public ObservableCollection<MenuItem> MenuItems { get; set; }
    public ISelectionChangedCommand SelectionChangedCommand { get; set; }
    [ObservableProperty]
    private IPageViewModel selectedView;
    public ILoadedCommand LoadedCommand { get; set; }
}