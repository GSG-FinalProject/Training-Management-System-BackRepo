using TMS.Domain.Entities;
using Task = System.Threading.Tasks.Task;
namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface IFeedbackRepository
{
    Task<Feedback> AddAsync(Feedback feedback);
    Task UpdateAsync(Feedback feedback);
    Task DeleteAsync(int id);
    Task<Feedback> GetByIdAsync(int id);
    Task<IEnumerable<Feedback>> GetAllAsync();
}
