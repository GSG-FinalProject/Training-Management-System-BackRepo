using TMS.Domain.DTOs.Task;
using EntityTask = TMS.Domain.Entities.Task; 

namespace TMS.Application.Abstracts;

public interface ITaskService
{
    Task<EntityTask> AddAsync(AddTaskRequest taskDto);
    Task UpdateAsync(UpdateTaskRequest taskDto);
    Task DeleteAsync(int taskId);
    Task<TaskResponseDto> GetByIdAsync(int taskId);
    Task<IEnumerable<TaskResponseDto>> GetAllAsync();
}
