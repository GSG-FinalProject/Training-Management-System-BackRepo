using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.Api.Controllers;
using TMS.Api.Responses;
using TMS.Domain.DTOs.shared;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;
using Task = System.Threading.Tasks.Task;

namespace TMSApi.Test.ControllersTest;
public class TraineeControllerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IResponseHandler> _responseHandlerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly TraineeController _controller;

    public TraineeControllerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _responseHandlerMock = new Mock<IResponseHandler>();
        _mapperMock = new Mock<IMapper>();
        _controller = new TraineeController(_unitOfWorkMock.Object, _responseHandlerMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetTraineeById_ShouldReturnSuccess_WhenTraineeExists()
    {
        // Arrange
        var traineeId = "1";
        var trainee = new Trainee { Id = traineeId, FirstName = "leen" };
        var traineeDto = new TraineeResponseDto { Id = traineeId, FirstName = "leen" };

        _unitOfWorkMock.Setup(u => u.TraineeRepository.GetByIdAsync(traineeId)).ReturnsAsync(trainee);
        _mapperMock.Setup(m => m.Map<TraineeResponseDto>(trainee)).Returns(traineeDto);
        _responseHandlerMock.Setup(r => r.Success(traineeDto, $"Trainee with ID {traineeId} retrieved successfully."))
            .Returns(new OkObjectResult(traineeDto));

        // Act
        var result = await _controller.GetTraineeById(traineeId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(traineeDto);
    }

    [Fact]
    public async Task UpdateTrainee_ShouldReturnSuccess_WhenTraineeIsUpdated()
    {
        // Arrange
        var traineeId = "1";
        var existingTrainee = new Trainee { Id = traineeId, FirstName = "leena" }; 
        var updatedTrainee = new Trainee { Id = traineeId, FirstName = "leen" }; 
        var traineeDto = new TraineeResponseDto { Id = traineeId, FirstName = "leen" }; 

        _unitOfWorkMock.Setup(u => u.TraineeRepository.GetByIdAsync(traineeId)).ReturnsAsync(existingTrainee);
        _unitOfWorkMock.Setup(u => u.TraineeRepository.UpdateAsync(traineeId, It.IsAny<Trainee>())).ReturnsAsync(updatedTrainee);
        _mapperMock.Setup(m => m.Map<TraineeResponseDto>(updatedTrainee)).Returns(traineeDto);
        _responseHandlerMock.Setup(r => r.Success(traineeDto, $"Trainee with ID {traineeId} updated successfully."))
            .Returns(new OkObjectResult(traineeDto));

        // Act
        var result = await _controller.UpdateTrainee(traineeId, new UpdateUserDto
        {
            FirstName = "leen",
            Email = "leen@example.com", 
            LastName = "odeh" 
        });

        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult.Value.Should().Be(traineeDto);
    }

}
