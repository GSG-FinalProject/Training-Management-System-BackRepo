using TMS.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface ISubmissionRepository
{
    Task<Submission> AddAsync(Submission submission);
    Task UpdateAsync(Submission submission);
    Task DeleteAsync(int submissionId);
    Task<Submission> GetByIdAsync(int submissionId);
    Task<IEnumerable<Submission>> GetAllAsync();
}
