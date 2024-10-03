using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Domain.Interfaces.Persistence;
namespace TMS.Infrastructure.DbContexts;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ITrainerRepository _trainerRepository;
    private readonly ITraineeRepository _traineeRepository;

    public UnitOfWork(AppDbContext context, ITrainerRepository trainerRepository, ITraineeRepository traineeRepository)
    {
        _context = context;
        _trainerRepository = trainerRepository;
        _traineeRepository = traineeRepository;
    }

    public ITrainerRepository TrainerRepository => _trainerRepository;
    public ITraineeRepository TraineeRepository => _traineeRepository;

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
