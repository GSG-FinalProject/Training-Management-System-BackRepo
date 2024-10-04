using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Domain.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    ITrainerRepository TrainerRepository { get; }
    ITraineeRepository TraineeRepository { get; }
    ITrainingFieldRepository TrainingFieldRepository { get; }
    ICourseRepository CoursesRepository { get; }
    ITaskRepository TasksRepository { get; }
    Task<int> CommitAsync(); 
}