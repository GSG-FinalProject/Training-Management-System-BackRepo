using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
namespace TMS.Infrastructure.Repositories;
public class SubmissionRepository : GenericRepository<Submission>, ISubmissionRepository
{
    private readonly AppDbContext _context;

    public SubmissionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
