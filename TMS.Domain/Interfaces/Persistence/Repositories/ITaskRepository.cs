using TMS.Domain.Entities;
using Task = TMS.Domain.Entities.Task;
namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface ITaskRepository 
{
    Task<Task> AddAsync(Task task);
    System.Threading.Tasks.Task UpdateAsync(Task task);
    System.Threading.Tasks.Task DeleteAsync(int taskId); 
    Task<Task> GetByIdAsync(int taskId); 
    Task<IEnumerable<Task>> GetAllAsync(); 
}