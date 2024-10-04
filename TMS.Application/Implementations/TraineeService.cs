using TMS.Application.Abstracts;
using TMS.Domain.DTOs.shared;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Application.Implementations;
public class TraineeService : ITraineeService
{
    public ITraineeRepository _traineeRepository { get; set; }
    public ITrainerRepository _trainerRepository { get; set; }
    public TraineeService(ITraineeRepository traineeRepository, ITrainerRepository trainerRepository)
    {
        _traineeRepository = traineeRepository;
        _trainerRepository = trainerRepository;

    }
    public async Task AssignTrainerToTraineeAsync(AssignTrainerTraineeDto assignDto)
    {
        var trainee = await _traineeRepository.GetByIdAsync(assignDto.TraineeId);
        if (trainee is null)
        {
            throw new KeyNotFoundException("Trainee not found.");
        }

        var trainer = await _trainerRepository.GetByIdAsync(assignDto.TrainerId);
        if (trainer is null)
        {
            throw new KeyNotFoundException("Trainer not found.");
        }

        if (trainer.TrainingFieldId != assignDto.TrainingFieldId)
        {
            throw new InvalidOperationException("Trainer does not belong to the specified training field.");
        }

        trainee.TrainerId = assignDto.TrainerId;  
        await _traineeRepository.UpdateAsync(trainee.Id, trainee);
    }
}
