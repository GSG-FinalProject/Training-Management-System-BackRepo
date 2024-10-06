using Moq;
using TMS.Application.Implementations;
using TMS.Domain.DTOs.shared;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using Task = System.Threading.Tasks.Task;

namespace TMSApplication.Test.Services.Test;
public class TraineeServiceTests
{
    private readonly Mock<ITraineeRepository> _traineeRepositoryMock;
    private readonly Mock<ITrainerRepository> _trainerRepositoryMock;
    private readonly TraineeService _traineeService;

    public TraineeServiceTests()
    {
        _traineeRepositoryMock = new Mock<ITraineeRepository>();
        _trainerRepositoryMock = new Mock<ITrainerRepository>();
        _traineeService = new TraineeService(_traineeRepositoryMock.Object, _trainerRepositoryMock.Object);
    }

    [Fact]
    public async Task AssignTrainerToTraineeAsync_ShouldThrowKeyNotFoundException_WhenTraineeNotFound()
    {
        // Arrange
        var assignDto = new AssignTrainerTraineeDto
        {
            TraineeId ="1",
            TrainerId = "2",
            TrainingFieldId = 1
        };

        _traineeRepositoryMock.Setup(repo => repo.GetByIdAsync(assignDto.TraineeId)).ReturnsAsync((Trainee)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _traineeService.AssignTrainerToTraineeAsync(assignDto));
    }

    [Fact]
    public async Task AssignTrainerToTraineeAsync_ShouldThrowKeyNotFoundException_WhenTrainerNotFound()
    {
        // Arrange
        var assignDto = new AssignTrainerTraineeDto
        {
            TraineeId = "1",
            TrainerId = "2",
            TrainingFieldId = 1
        };

        var trainee = new Trainee { Id = "1" };
        _traineeRepositoryMock.Setup(repo => repo.GetByIdAsync(assignDto.TraineeId)).ReturnsAsync(trainee);
        _trainerRepositoryMock.Setup(repo => repo.GetByIdAsync(assignDto.TrainerId)).ReturnsAsync((Trainer)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _traineeService.AssignTrainerToTraineeAsync(assignDto));
    }

    [Fact]
    public async Task AssignTrainerToTraineeAsync_ShouldThrowInvalidOperationException_WhenTrainerDoesNotBelongToTrainingField()
    {
        // Arrange
        var assignDto = new AssignTrainerTraineeDto
        {
            TraineeId = "1",
            TrainerId = "2",
            TrainingFieldId = 1
        };

        var trainee = new Trainee { Id = "1" };
        var trainer = new Trainer { Id = "2", TrainingFieldId = 3 }; 

        _traineeRepositoryMock.Setup(repo => repo.GetByIdAsync(assignDto.TraineeId)).ReturnsAsync(trainee);
        _trainerRepositoryMock.Setup(repo => repo.GetByIdAsync(assignDto.TrainerId)).ReturnsAsync(trainer);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _traineeService.AssignTrainerToTraineeAsync(assignDto));
    }
}