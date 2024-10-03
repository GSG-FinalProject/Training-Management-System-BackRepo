using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Domain.Interfaces.Persistence;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Admin> Admins { get; }
    IGenericRepository<Trainer> Trainers { get; }
    IGenericRepository<Trainee> Trainees { get; }

    Task<int> CompleteAsync();
}