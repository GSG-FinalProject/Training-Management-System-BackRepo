using Task = TMS.Domain.Entities.Task;
namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface ITaskRepository : IGenericRepository<Task>
{
}