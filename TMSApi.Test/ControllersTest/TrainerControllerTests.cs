using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.Api.Controllers;
using TMS.Api.Responses;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;
using Task = System.Threading.Tasks.Task;

namespace TMSApi.Test.ControllersTest;

public class TrainerControllerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IResponseHandler> _responseHandlerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly TrainerController _controller;

    public TrainerControllerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _responseHandlerMock = new Mock<IResponseHandler>();
        _mapperMock = new Mock<IMapper>();
        _controller = new TrainerController(_unitOfWorkMock.Object, _responseHandlerMock.Object, _mapperMock.Object);
    }


    [Fact]
    public async Task GetTrainerById_ShouldReturnSuccess_WhenTrainerExists()
    {
        // Arrange
        var trainerId = "1";
        var trainer = new Trainer { Id = trainerId, FirstName = "aseel" };
        var trainerDto = new TrainerResponseDto { Id = trainerId, FirstName = "aseel" };

        _unitOfWorkMock.Setup(u => u.TrainerRepository.GetByIdAsync(trainerId)).ReturnsAsync(trainer);
        _mapperMock.Setup(m => m.Map<TrainerResponseDto>(trainer)).Returns(trainerDto);
        _responseHandlerMock.Setup(r => r.Success(trainerDto, $"Trainer with ID {trainerId} retrieved successfully."))
            .Returns(new OkObjectResult(trainerDto));

        // Act
        var result = await _controller.GetTrainerById(trainerId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(trainerDto);
    }

    [Fact]
    public async Task GetTrainerById_ShouldReturnNotFound_WhenTrainerDoesNotExist()
    {
        // Arrange
        var trainerId = "1";

        _unitOfWorkMock.Setup(u => u.TrainerRepository.GetByIdAsync(trainerId)).ReturnsAsync((Trainer)null);
        _responseHandlerMock.Setup(r => r.NotFound("Trainer not found."))
            .Returns(new NotFoundResult());

        // Act
        var result = await _controller.GetTrainerById(trainerId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task UpdateTrainer_ShouldReturnSuccess_WhenTrainerIsUpdated()
    {
        // Arrange
        var trainerId = "1";
        var trainer = new Trainer { Id = trainerId, FirstName = "osaid" };
        var updatedTrainer = new Trainer { Id = trainerId, FirstName = "osaid" };
        var trainerDto = new TrainerResponseDto { Id = trainerId, FirstName = "osaid" };

        _unitOfWorkMock.Setup(u => u.TrainerRepository.UpdateAsync(trainerId, updatedTrainer)).ReturnsAsync(updatedTrainer);
        _mapperMock.Setup(m => m.Map<TrainerResponseDto>(updatedTrainer)).Returns(trainerDto);
        _responseHandlerMock.Setup(r => r.Success(trainerDto, $"Trainer with ID {trainerId} updated successfully."))
            .Returns(new OkObjectResult(trainerDto));

        // Act
        var result = await _controller.UpdateTrainer(trainerId, updatedTrainer);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(trainerDto);
    }

    [Fact]
    public async Task DeleteTrainer_ShouldReturnNoContent_WhenTrainerIsDeleted()
    {
        // Arrange
        var trainerId = "1";

        _unitOfWorkMock.Setup(u => u.TrainerRepository.DeleteAsync(trainerId));
        _responseHandlerMock.Setup(r => r.NotFound("Trainer not found."))
            .Returns(new NotFoundResult());

        // Act
        var result = await _controller.DeleteTrainer(trainerId);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }
}
