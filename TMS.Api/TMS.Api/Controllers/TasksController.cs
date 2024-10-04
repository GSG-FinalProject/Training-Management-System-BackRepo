using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Task;

namespace TMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public TaskController(ITaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> AddAsync(AddTaskRequest taskDto)
    {
        var taskEntity = await _taskService.AddAsync(taskDto);
        var responseDto = _mapper.Map<TaskResponseDto>(taskEntity);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = responseDto.Id }, responseDto);
    }

    [HttpPut("{taskId}")]
    public async Task<ActionResult> UpdateAsync(int taskId, UpdateTaskRequest taskDto)
    {
        await _taskService.UpdateAsync(taskDto);
        return NoContent();
    }

    [HttpDelete("{taskId}")]
    public async Task<ActionResult> DeleteAsync(int taskId)
    {
        await _taskService.DeleteAsync(taskId);
        return NoContent();
    }

    [HttpGet("{taskId}")]
    public async Task<ActionResult<TaskResponseDto>> GetByIdAsync(int taskId)
    {
        var taskResponseDto = await _taskService.GetByIdAsync(taskId);
        if (taskResponseDto is null)
        {
            return NotFound();
        }

        return Ok(taskResponseDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAllAsync()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }
}
