using Microsoft.EntityFrameworkCore;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
using Task = System.Threading.Tasks.Task;

namespace TMS.Infrastructure.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Task> AddAsync(Domain.Entities.Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task; 
    }

    public async Task UpdateAsync(Domain.Entities.Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int taskId)
    {
        var task = await GetByIdAsync(taskId);
        if (task is not null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Task not found");
        }
    }

    public async Task<Domain.Entities.Task> GetByIdAsync(int taskId)
    {
        return await _context.Tasks.FindAsync(taskId);
    }

    public async Task<IEnumerable<Domain.Entities.Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
}
