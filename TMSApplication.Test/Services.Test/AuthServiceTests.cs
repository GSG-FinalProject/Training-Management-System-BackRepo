using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Data;
using TMS.Application.Abstracts.IAuthService;
using TMS.Application.Implementations;
using TMS.Domain.DTOs.Admin;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;
using TMS.Domain.Enums;
using TMS.Domain.Interfaces.ILogger;
using Task = System.Threading.Tasks.Task;

namespace TMSApplication.Test.Services.Test;

public class AuthServiceTests
{
    private readonly Mock<IUserManager> _userManagerMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<ILog> _logMock;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _userManagerMock = new Mock<IUserManager>();
        _tokenServiceMock = new Mock<ITokenService>();
        _logMock = new Mock<ILog>();
        _authService = new AuthService(_userManagerMock.Object, _tokenServiceMock.Object, _logMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task RegisterAdminAsync_ShouldReturnAdminResponseDto_WhenRegistrationSucceeds()
    {
        // Arrange
        var registerAdminDto = new RegisterAdminDto
        {
            Email = "admin@example.com",
            FirstName = "Admin",
            LastName = "User",
            Password = "StrongPassword123"
        };

        var admin = new Admin { Id = "1", Email = registerAdminDto.Email, UserName = registerAdminDto.Email, UserType = Role.Admin };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Admin>(), registerAdminDto.Password))
       .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _authService.RegisterAdminAsync(registerAdminDto);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be(admin.Email);
        result.UserType.Should().Be(Role.Admin);
    }

    [Fact]
    public async System.Threading.Tasks.Task RegisterAdminAsync_ShouldThrowException_WhenRegistrationFails()
    {
        // Arrange
        var registerAdminDto = new RegisterAdminDto
        {
            Email = "admin@example.com",
            FirstName = "Admin",
            LastName = "User",
            Password = "StrongPassword123"
        };

        var errors = new[] { "Email already exists." };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Admin>(), registerAdminDto.Password))
            .ReturnsAsync(IdentityResult.Failed(errors.Select(e => new IdentityError { Description = e }).ToArray()));

        // Act
        Func<System.Threading.Tasks.Task> act = async () => await _authService.RegisterAdminAsync(registerAdminDto);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage($"Failed to register admin: {string.Join(", ", errors)}");
    }

    [Fact]
    public async System.Threading.Tasks.Task RegisterTrainerAsync_ShouldReturnTrainerResponseDto_WhenRegistrationSucceeds()
    {
        // Arrange
        var registerTrainerDto = new RegisterTrainerDto
        {
            Email = "leen3@gmail.com",
            FirstName = "leem",
            LastName = "odeh",
            Password = "leenodeh123"
        };

        var trainer = new Trainer { Id = "1", Email = registerTrainerDto.Email, UserName = registerTrainerDto.Email, UserType = Role.Trainer };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Trainer>(), registerTrainerDto.Password))
    .ReturnsAsync(IdentityResult.Success);


        // Act
        var result = await _authService.RegisterTrainerAsync(registerTrainerDto);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be(trainer.Email);
        result.UserType.Should().Be(Role.Trainer);
    }

    [Fact]
    public async System.Threading.Tasks.Task RegisterTrainerAsync_ShouldThrowException_WhenRegistrationFails()
    {
        // Arrange
        var registerTrainerDto = new RegisterTrainerDto
        {
            Email = "amin@example.com",
            FirstName = "amin",
            LastName = "eid",
            Password = "Amineid453test"
        };

        var errors = new[] { "Email already exists." };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Trainer>(), registerTrainerDto.Password))
            .ReturnsAsync(IdentityResult.Failed(errors.Select(e => new IdentityError { Description = e }).ToArray()));

        // Act
        Func<System.Threading.Tasks.Task> act = async () => await _authService.RegisterTrainerAsync(registerTrainerDto);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage($"Failed to register Trainer: {string.Join(", ", errors)}");
    }

    [Fact]
    public async Task RegisterTraineeAsync_ShouldReturnTraineeResponseDto_WhenRegistrationSucceeds()
    {
        // Arrange
        var registerTraineeDto = new RegisterTraineeDto
        {
            Email = "tala@example.com",
            FirstName = "tala",
            LastName = "Ismael",
            Password = "TalaTala12",
            TrainingHours = 400,
            TrainingProgram = "QA"
        };

        var trainee = new Trainee { Id = "1", Email = registerTraineeDto.Email, UserName = registerTraineeDto.Email, UserType = Role.Trainee };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Trainee>(), registerTraineeDto.Password))
       .ReturnsAsync(IdentityResult.Success);


        // Act
        var result = await _authService.RegisterTraineeAsync(registerTraineeDto);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be(trainee.Email);
        result.UserType.Should().Be(Role.Trainee);
        result.TrainingHours.Should().Be(registerTraineeDto.TrainingHours);
    }

    [Fact]
    public async System.Threading.Tasks.Task RegisterTraineeAsync_ShouldThrowException_WhenRegistrationFails()
    {
        // Arrange
        var registerTraineeDto = new RegisterTraineeDto
        {
            Email = "layan@example.com",
            FirstName = "layan",
            LastName = "alfar",
            Password = "pass123",
            TrainingHours = 200,
            TrainingProgram = "Backend"
        };

        var errors = new[] { "Email already exists." };
        _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<Trainee>(), registerTraineeDto.Password))
            .ReturnsAsync(IdentityResult.Failed(errors.Select(e => new IdentityError { Description = e }).ToArray()));

        // Act
        Func<Task> act = async () => await _authService.RegisterTraineeAsync(registerTraineeDto);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage($"Failed to register Trainee: {string.Join(", ", errors)}");
    }
}
