namespace TMS.Domain.Interfaces.Persistence.Repositories;
public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<T> UpdateAsync(string id, T entity);
    Task<string> DeleteAsync(string id);
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> UpdateAsync(int id , T entity);
    Task<string> DeleteAsync(int id);
}