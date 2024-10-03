using TMS.Domain.Entities;
namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface ITraineeRepository : IGenericRepository<Trainee>
{
    Task<IEnumerable<Trainee>> GetByTrainingHoursAsync(int hours);
}