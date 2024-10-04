using TMS.Domain.DTOs.Task;

namespace TMS.Application.Abstracts;
public interface ITaskService
{
    Task<Task> AddAsync(AddTaskRequest taskDto);
    Task UpdateAsync(UpdateTaskRequest taskDto);
    Task DeleteAsync(int taskId);
    Task<TaskResponseDto> GetByIdAsync(int taskId);
    Task<IEnumerable<TaskResponseDto>> GetAllAsync();
}