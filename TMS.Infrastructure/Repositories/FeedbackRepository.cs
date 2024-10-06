using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
using Task = System.Threading.Tasks.Task;
namespace TMS.Infrastructure.Repositories;
public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
{
    private readonly AppDbContext _context;

    public FeedbackRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
