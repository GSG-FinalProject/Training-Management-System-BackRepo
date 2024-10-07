using AutoMapper;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Task;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using EntityTask = TMS.Domain.Entities.Task;
using Task = System.Threading.Tasks.Task;

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
        return await _taskRepository.CreateAsync(taskEntity);
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
    public async Task UpdateAsync(int taskId, AddTaskRequest taskDto)
    {
        var existingEntity = await _taskRepository.GetByIdAsync(taskId);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {taskId} not found.");
        }

        existingEntity.Title = taskDto.Title;
        existingEntity.Description = taskDto.Description;
        existingEntity.Deadline = taskDto.Deadline;
        existingEntity.CourseId = taskDto.CourseId;

        await _taskRepository.UpdateAsync(taskId, existingEntity);
    }



}
