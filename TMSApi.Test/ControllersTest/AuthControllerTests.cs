using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using TMS.Api.Controllers;
using TMS.Api.Responses;
using TMS.Application.Abstracts.IAuthService;
using TMS.Domain.DTOs.Admin;
using TMS.Domain.DTOs.shared;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;
using TMS.Domain.Enums;
using TMS.Domain.Interfaces.ILogger;
using TMS.Domain.DTOs.Trainer;
using Microsoft.EntityFrameworkCore;

namespace TMSApi.Test.AuthControllerTest;
public class AuthControllerTests
{
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly Mock<IResponseHandler> _responseHandlerMock;
    private readonly Mock<ILog> _logMock;
    private readonly Mock<IUserManager> _userManagerMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
        _authServiceMock = new Mock<IAuthService>();
        _responseHandlerMock = new Mock<IResponseHandler>();
        _logMock = new Mock<ILog>();
        _userManagerMock = new Mock<IUserManager>();
        _tokenServiceMock = new Mock<ITokenService>();
        _authController = new AuthController(
            _authServiceMock.Object,
            _responseHandlerMock.Object,
            _logMock.Object,
            _userManagerMock.Object,
            _tokenServiceMock.Object
        );
    }

    [Fact]
    public async Task RegisterAdmin_ShouldReturnSuccess_WhenAdminIsRegistered()
    {
        // Arrange
        var registerAdminDto = new RegisterAdminDto { Email = "admin@example.com", Password = "password123" };
        var expectedResponse = new AdminResponseDto { Email = registerAdminDto.Email };
        _authServiceMock.Setup(a => a.RegisterAdminAsync(registerAdminDto)).ReturnsAsync(expectedResponse);
        _responseHandlerMock.Setup(r => r.Success(expectedResponse, "Admin registered successfully."))
            .Returns(new OkObjectResult(expectedResponse));

        // Act
        var result = await _authController.RegisterAdmin(registerAdminDto);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task RegisterAdmin_ShouldReturnBadRequest_WhenExceptionThrown()
    {
        // Arrange
        var registerAdminDto = new RegisterAdminDto { Email = "admin@example.com", Password = "password123" };
        _authServiceMock.Setup(a => a.RegisterAdminAsync(registerAdminDto)).ThrowsAsync(new Exception("Error"));

        _responseHandlerMock.Setup(r => r.BadRequest("Error"))
            .Returns(new BadRequestObjectResult("Error"));

        // Act
        var result = await _authController.RegisterAdmin(registerAdminDto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task RegisterTrainer_ShouldReturnSuccess_WhenTrainerIsRegistered()
    {
        // Arrange
        var registerTrainerDto = new RegisterTrainerDto { Email = "trainer@example.com", Password = "password123" };
        var expectedResponse = new TrainerResponseDto { Email = registerTrainerDto.Email };
        _authServiceMock.Setup(a => a.RegisterTrainerAsync(registerTrainerDto)).ReturnsAsync(expectedResponse);
        _responseHandlerMock.Setup(r => r.Success(expectedResponse, "Trainer registered successfully."))
            .Returns(new OkObjectResult(expectedResponse));

        // Act
        var result = await _authController.RegisterTrainer(registerTrainerDto);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task RegisterTrainee_ShouldReturnSuccess_WhenTraineeIsRegistered()
    {
        // Arrange
        var registerTraineeDto = new RegisterTraineeDto { Email = "trainee@example.com", Password = "password123" };
        var expectedResponse = new TraineeResponseDto { Email = registerTraineeDto.Email };
        _authServiceMock.Setup(a => a.RegisterTraineeAsync(registerTraineeDto)).ReturnsAsync(expectedResponse);
        _responseHandlerMock.Setup(r => r.Success(expectedResponse, "Trainee registered successfully."))
            .Returns(new OkObjectResult(expectedResponse));

        // Act
        var result = await _authController.RegisterTrainee(registerTraineeDto);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(expectedResponse);
    }

    [Fact]
    public async Task Login_ShouldReturnBadRequest_WhenCredentialsAreInvalid()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "invalid@example.com", Password = "wrongpassword" };
        _userManagerMock.Setup(um => um.FindByEmailAsync(loginDto.Email)).ReturnsAsync((User)null);

        // Act
        var result = await _authController.Login(loginDto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }
}
