using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.NoNavPage;

public class NoNavPageViewModelFactory(
    INavigateToNavPageCommand navigateToNavPageCommand) : PageViewModelFactoryBase<NoNavPageViewModel>
{
    public override NoNavPageViewModel Invoke()
    {
        return new NoNavPageViewModel
        {
            NavigateToNavPageCommand = navigateToNavPageCommand
        };
    }
}