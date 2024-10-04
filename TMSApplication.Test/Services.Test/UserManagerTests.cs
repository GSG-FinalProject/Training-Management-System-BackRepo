using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using TMS.Application.Abstracts.IAuthService;
using TMS.Application.Implementations;
using TMS.Domain.Entities;

namespace TMSApplication.Test.Services.Test;

public class UserManagerTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly IUserManager _userManager;

    public UserManagerTests()
    {
        var store = new Mock<IUserStore<User>>();
        _userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
        _userManager = new UserManager(_userManagerMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task FindByEmailAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var email = "leenodeh@example.com";
        var user = new User { Email = email, UserName = email };

        _userManagerMock.Setup(um => um.FindByEmailAsync(email))
            .ReturnsAsync(user);

        // Act
        var result = await _userManager.FindByEmailAsync(email);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be(email);
    }

    [Fact]
    public async System.Threading.Tasks.Task CheckPasswordAsync_ShouldReturnTrue_WhenPasswordIsCorrect()
    {
        // Arrange
        var user = new User { Email = "moneer5@example.com", UserName = "moneer5" };
        var password = "pass123";

        _userManagerMock.Setup(um => um.CheckPasswordAsync(user, password))
            .ReturnsAsync(true);

        // Act
        var result = await _userManager.CheckPasswordAsync(user, password);

        // Assert
        result.Should().BeTrue();
    }
}
