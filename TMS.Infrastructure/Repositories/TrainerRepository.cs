using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;

namespace TMS.Infrastructure.Repositories;

public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
{
    public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}