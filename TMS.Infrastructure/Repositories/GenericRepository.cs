using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
namespace TMS.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var entity = await _appDbContext.Set<T>().FindAsync(id);

        if (entity is null)
            throw new KeyNotFoundException($"Entity with ID {id} not found.");

        _appDbContext.Set<T>().Remove(entity);
        await _appDbContext.SaveChangesAsync();

        return "Entity deleted successfully.";
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var entity = await _appDbContext.Set<T>().FindAsync(id);

        if (entity is null)
            throw new KeyNotFoundException($"Entity with ID {id} not found.");

        return entity;
    }

    public async Task<T> UpdateAsync(string id, T entity)
    {
        var existingEntity = await _appDbContext.Set<T>().FindAsync(id);

        if (existingEntity is null)
            throw new KeyNotFoundException($"Entity with ID {id} not found.");

        _appDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _appDbContext.SaveChangesAsync();

        return existingEntity;
    }
}