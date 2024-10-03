using System;

using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Domain.Interfaces.Persistence;

namespace TMS.Infrastructure.DbContexts;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Admins = new GenericRepository<Admin>(_context);
        Trainers = new GenericRepository<Trainer>(_context);
        Trainees = new GenericRepository<Trainee>(_context);
    }

    public IGenericRepository<Admin> Admins { get; private set; }
    public IGenericRepository<Trainer> Trainers { get; private set; }
    public IGenericRepository<Trainee> Trainees { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}