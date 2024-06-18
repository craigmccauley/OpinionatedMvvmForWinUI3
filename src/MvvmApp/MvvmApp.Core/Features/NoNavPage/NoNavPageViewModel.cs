using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NoNavPage;
public class NoNavPageViewModel : IPageViewModel
{
    public INavigateToNavPageCommand NavigateToNavPageCommand { get; set; }
}