using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;

namespace TMS.Infrastructure.Repositories;
public class TaskRepository : GenericRepository<Domain.Entities.Task>, ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
