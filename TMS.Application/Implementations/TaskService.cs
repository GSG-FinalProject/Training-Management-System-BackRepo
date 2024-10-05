using AutoMapper;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Task;
using TMS.Domain.Interfaces.Persistence.Repositories;
using EntityTask = TMS.Domain.Entities.Task; 

namespace TMS.Application.Implementations;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<EntityTask> AddAsync(AddTaskRequest taskDto)
    {
        var taskEntity = _mapper.Map<EntityTask>(taskDto);
        return await _taskRepository.AddAsync(taskEntity);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskRequest taskDto)
    {
        
        var taskEntity = _mapper.Map<EntityTask>(taskDto);
        await _taskRepository.UpdateAsync(taskEntity);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int taskId)
    {
        await _taskRepository.DeleteAsync(taskId);
    }

    public async Task<TaskResponseDto> GetByIdAsync(int taskId)
    {
        var taskEntity = await _taskRepository.GetByIdAsync(taskId);
        return _mapper.Map<TaskResponseDto>(taskEntity);
    }

    public async Task<IEnumerable<TaskResponseDto>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
    }
}
