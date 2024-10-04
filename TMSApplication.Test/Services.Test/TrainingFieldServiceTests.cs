using FluentAssertions;
using Moq;
using TMS.Application.Implementations;
using TMS.Domain.DTOs.TrainingField;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using Task = System.Threading.Tasks.Task;
namespace TMSApi.Test.ServiceTests;
public class TrainingFieldServiceTests
{
    private readonly Mock<ITrainingFieldRepository> _mockTrainingFieldRepository;
    private readonly TrainingFieldService _service;

    public TrainingFieldServiceTests()
    {
        _mockTrainingFieldRepository = new Mock<ITrainingFieldRepository>();
        _service = new TrainingFieldService(_mockTrainingFieldRepository.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsTrainingFieldDto_WhenTrainingFieldExists()
    {
        // Arrange
        var trainingField = new TrainingField { Id = 1, Name = "Node.js", Description = "Node.js Description" };
        _mockTrainingFieldRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(trainingField);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(trainingField.Id);
        result.Name.Should().Be(trainingField.Name);
        result.Description.Should().Be(trainingField.Description);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsKeyNotFoundException_WhenTrainingFieldDoesNotExist()
    {
        // Arrange
        _mockTrainingFieldRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((TrainingField)null);

        // Act
        Func<Task> act = async () => await _service.GetByIdAsync(1);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage("Training field not found.");
    }

    [Fact]
    public async Task CreateAsync_ReturnsCreatedTrainingField_WhenCalled()
    {
        // Arrange
        var trainingFieldDto = new AddTrainingFieldDto { Name = "Node.js", Description = "Node.js Description" };
        var createdTrainingField = new TrainingField { Id = 1, Name = trainingFieldDto.Name, Description = trainingFieldDto.Description };

        _mockTrainingFieldRepository.Setup(r => r.CreateAsync(It.IsAny<TrainingField>())).ReturnsAsync(createdTrainingField);

        // Act
        var result = await _service.CreateAsync(trainingFieldDto);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(createdTrainingField.Id);
        result.Name.Should().Be(createdTrainingField.Name);
        result.Description.Should().Be(createdTrainingField.Description);
    }

    [Fact]
    public async Task DeleteAsync_ReturnsMessage_WhenCalled()
    {
        // Arrange
        _mockTrainingFieldRepository.Setup(r => r.DeleteAsync(1)).ReturnsAsync("Entity deleted successfully.");

        // Act
        var result = await _service.DeleteAsync(1);

        // Assert
        result.Should().Be("Entity deleted successfully.");
    }

    [Fact]
    public async Task GetAllAsync_ReturnsTrainingFieldDtos_WhenTrainingFieldsExist()
    {
        // Arrange
        var trainingFields = new List<TrainingField>
        {
            new TrainingField { Id = 1, Name = "Node.js", Description = "Node.js Description" },
            new TrainingField { Id = 2, Name = "C#", Description = "C# Description" }
        };

        _mockTrainingFieldRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(trainingFields);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetAllAsync_ThrowsKeyNotFoundException_WhenNoTrainingFieldsExist()
    {
        // Arrange
        _mockTrainingFieldRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<TrainingField>());

        // Act
        Func<Task> act = async () => await _service.GetAllAsync();

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage("No training fields found.");
    }
}
