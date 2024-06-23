using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Core.Infrastructure.Application;

namespace MvvmApp.Core.Features.NavPage;

public partial class MenuItem : ObservableObject
{
    [ObservableProperty]
    private bool isSelected;
    public Page NavDestination { get; set; }
    public string Content { get; set; } 
    public string Glyph { get; set; }
    public NavPageViewModel Parent { get; set; }
}