using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;

namespace TMS.Infrastructure.Repositories;
public class TrainingFieldRepository : GenericRepository<TrainingField>, ITrainingFieldRepository
{
    public TrainingFieldRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

}