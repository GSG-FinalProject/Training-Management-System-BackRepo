using TMS.Domain.DTOs.TrainingField;
using TMS.Domain.Entities;
using Task = System.Threading.Tasks.Task;
namespace TMS.Application.Abstracts;
public interface ITrainingFieldService
{
    Task<TrainingFieldDto> GetByIdAsync(int id); 
    Task<TrainingField> CreateAsync(AddTrainingFieldDto trainingFieldDto); 
    Task UpdateAsync(int id, AddTrainingFieldDto trainingFieldDto);
    Task<string> DeleteAsync(int id);
    Task<IEnumerable<TrainingFieldDto>> GetAllAsync(); 
}