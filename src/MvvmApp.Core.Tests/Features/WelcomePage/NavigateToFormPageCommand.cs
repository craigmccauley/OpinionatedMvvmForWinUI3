using AutoFixture.Xunit2;
using FluentAssertions;
using MvvmApp.Core.Features.NavPage;
using MvvmApp.Core.Features.WelcomePage;
using MvvmApp.Core.Infrastructure.Application;
using MvvmApp.Core.Tests.TestHelpers;
using NSubstitute;

namespace MvvmApp.Core.Tests.Features.WelcomePage;
public class NavigateToFormPageCommandTests
{
    [Theory, AutoSubData]
    public void Execute_ShouldNavigateToFormPage(
        [Frozen] IHooks hooks,
        [NoAutoProperties] NavPageViewModel navPageViewModel,
        NavigateToFormPageCommand sut)
    {
        // Arrange
        navPageViewModel.MenuItems =
        [
            .. Pages.All.Select(p => new MenuItem { NavDestination = p })
        ];

        hooks.GetPageViewModel(Pages.NavPage).Returns(navPageViewModel);
        hooks.RunOnUIThreadAsync(Arg.Any<Action>()).Returns(info =>
        {
            info.Arg<Action>()?.Invoke();
            return Task.CompletedTask;
        });


        sut.ExecuteCompleted += ExecuteCompleted;

        // Act
        sut.Execute(null);

        // Assert
        void ExecuteCompleted(object sender, EventArgs e)
        {
            navPageViewModel.SelectedMenuItem.Should().Be(
                navPageViewModel.MenuItems.First(mi => mi.NavDestination == Pages.FormPage));
        }
    }
}
