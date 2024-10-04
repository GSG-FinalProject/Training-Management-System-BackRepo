using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.Api.Controllers;
using TMS.Api.Responses;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.TrainingField;
namespace TMSApi.Test.ControllersTest;

public class TrainingFieldControllerTests
{
    private readonly Mock<ITrainingFieldService> _mockTrainingFieldService;
    private readonly Mock<IResponseHandler> _mockResponseHandler;
    private readonly TrainingFieldController _controller;

    public TrainingFieldControllerTests()
    {
        _mockTrainingFieldService = new Mock<ITrainingFieldService>();
        _mockResponseHandler = new Mock<IResponseHandler>();
        _controller = new TrainingFieldController(_mockTrainingFieldService.Object, _mockResponseHandler.Object);
    }


    [Fact]
    public async Task GetByIdAsync_ReturnsNotFound_WhenTrainingFieldDoesNotExist()
    {
        // Arrange
        _mockTrainingFieldService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TrainingFieldDto)null);
        _mockResponseHandler.Setup(r => r.NotFound("Training field not found."))
            .Returns(new NotFoundObjectResult(new { Message = "Training field not found." }));

        // Act
        var result = await _controller.GetByIdAsync(1);
        result.Should().BeOfType<NotFoundObjectResult>();
    }


    [Fact]
    public async Task UpdateAsync_ReturnsNoContent_WhenTrainingFieldIsUpdated()
    {
        // Arrange
        var trainingFieldDto = new AddTrainingFieldDto { Name = "Node.js", Description = "Node.js Description" };
        _mockTrainingFieldService.Setup(s => s.UpdateAsync(1, trainingFieldDto)).Returns(Task.CompletedTask);
        _mockResponseHandler.Setup(r => r.NoContent("Training field updated successfully.")).Returns(new NoContentResult());

        var result = await _controller.UpdateAsync(1, trainingFieldDto);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteAsync_ReturnsNoContent_WhenTrainingFieldIsDeleted()
    {
        // Arrange
        _mockTrainingFieldService.Setup(s => s.DeleteAsync(1)).ReturnsAsync("Entity deleted successfully.");
        _mockResponseHandler.Setup(r => r.NoContent("Training field deleted successfully.")).Returns(new NoContentResult());

        var result = await _controller.DeleteAsync(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }
}
