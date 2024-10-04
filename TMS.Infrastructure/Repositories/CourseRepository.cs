using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;

namespace TMS.Infrastructure.Repositories;
public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}