using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;

namespace TMS.Infrastructure.Repositories;

public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
{
    public TraineeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Trainee>> GetByTrainingHoursAsync(int hours)
    {
        return await _appDbContext.Set<Trainee>().Where(t => t.TrainingHours >= hours).ToListAsync();
    }
}