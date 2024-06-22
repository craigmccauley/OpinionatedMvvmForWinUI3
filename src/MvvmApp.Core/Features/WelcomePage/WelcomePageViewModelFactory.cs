using MvvmApp.Core.Infrastructure.Common;

namespace MvvmApp.Core.Features.WelcomePage;

public class WelcomePageViewModelFactory(
    INavigateToNoNavPageCommand navigateToNoNavPageCommand) : PageViewModelFactoryBase<WelcomePageViewModel>
{
    public override WelcomePageViewModel Invoke()
    {

        var vm = new WelcomePageViewModel
        {
            NavigateToNoNavPageCommand = navigateToNoNavPageCommand,
        };
        return vm;
    }
}