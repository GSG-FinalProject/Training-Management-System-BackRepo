using TMS.Infrastructure.Repositories;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using System.Threading.Tasks;
using TMS.Domain.Interfaces.Persistence;

namespace TMS.Infrastructure.DbContexts;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ITrainerRepository _trainerRepository;
    private readonly ITraineeRepository _traineeRepository;
    private readonly ITaskRepository _taskRepository;
    public UnitOfWork(
        AppDbContext context,
        ITrainerRepository trainerRepository,
        ITraineeRepository traineeRepository, ITaskRepository taskRepository)
    {
        _context = context;
        _trainerRepository = trainerRepository;
        _traineeRepository = traineeRepository;
        TrainingFieldRepository = new TrainingFieldRepository(context);
        CoursesRepository = new CourseRepository(context);
        _taskRepository = taskRepository;
    }

    public ITrainerRepository TrainerRepository => _trainerRepository;
    public ITraineeRepository TraineeRepository => _traineeRepository;
    public ITrainingFieldRepository TrainingFieldRepository { get; }
    public ICourseRepository CoursesRepository { get; }

    public ITaskRepository TasksRepository => throw new NotImplementedException();

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
