using TMS.Application.Abstracts;
using TMS.Domain.DTOs.TrainingField;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;
using TMS.Domain.Interfaces.Persistence.Repositories;
using Task = System.Threading.Tasks.Task;

namespace TMS.Application.Implementations;
public class TrainingFieldService : ITrainingFieldService
{
    private readonly ITrainingFieldRepository _trainingFieldRepository;

    public TrainingFieldService(ITrainingFieldRepository trainingFieldRepository)
    {
        _trainingFieldRepository = trainingFieldRepository;
    }

    public async Task<TrainingFieldDto> GetByIdAsync(int id)
    {
        var trainingField = await _trainingFieldRepository.GetByIdAsync(id);
        if (trainingField is null)
        {
            throw new KeyNotFoundException("Training field not found.");
        }

        return new TrainingFieldDto
        {
            Id = trainingField.Id,
            Name = trainingField.Name
        };
    }


    public async Task<TrainingField> CreateAsync(AddTrainingFieldDto trainingFieldDto)
    {
        var trainingField = new TrainingField
        {
            Name = trainingFieldDto.Name
        };
        return await _trainingFieldRepository.CreateAsync(trainingField);
    }

    public async Task UpdateAsync(int id, AddTrainingFieldDto trainingFieldDto)
    {
        var trainingField = new TrainingField
        {
            Id = id,
            Name = trainingFieldDto.Name
        };
        await _trainingFieldRepository.UpdateAsync(id,trainingField);
    }

    public async Task<string> DeleteAsync(int id)
    {
        return await _trainingFieldRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TrainingFieldDto>> GetAllAsync()
    {
        var trainingFields = await _trainingFieldRepository.GetAllAsync();

        if (trainingFields is null || !trainingFields.Any())
        {
            throw new KeyNotFoundException("No training fields found.");
        }

        var trainingFieldDtos = trainingFields.Select(trainingField => new TrainingFieldDto
        {
            Id = trainingField.Id,
            Name = trainingField.Name
        });

        return trainingFieldDtos;
    }

}