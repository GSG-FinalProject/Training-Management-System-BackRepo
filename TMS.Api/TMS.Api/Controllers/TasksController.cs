﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Task;

namespace TMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IResponseHandler _responseHandler;
    private readonly IMapper _mapper;

    public TaskController(ITaskService taskService, IResponseHandler responseHandler, IMapper mapper)
    {
        _taskService = taskService;
        _responseHandler = responseHandler;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddTaskRequest taskDto)
    {
        try
        {
            var taskEntity = await _taskService.AddAsync(taskDto);
            var responseDto = _mapper.Map<TaskResponseDto>(taskEntity);
            return _responseHandler.Created(responseDto, "Task created successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest("An error occurred while creating the task: " + ex.Message);
        }
    }


    [HttpPut("{taskId}")]
    public async Task<IActionResult> UpdateAsync(int taskId, [FromBody] UpdateTaskRequest taskDto)
    {
        try
        {
            await _taskService.UpdateAsync(taskDto);
            return _responseHandler.NoContent("Task updated successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest("An error occurred while updating the task.");
        }
    }

    [HttpDelete("{taskId}")]
    public async Task<IActionResult> DeleteAsync(int taskId)
    {
        await _taskService.DeleteAsync(taskId);
        return _responseHandler.NoContent("Task deleted successfully.");
    }

    [HttpGet("{taskId}")]
    public async Task<IActionResult> GetByIdAsync(int taskId)
    {
        var taskResponseDto = await _taskService.GetByIdAsync(taskId);
        if (taskResponseDto is null)
        {
            return _responseHandler.NotFound($"Task with ID {taskId} not found.");
        }

        return _responseHandler.Success(taskResponseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var tasks = await _taskService.GetAllAsync();
        return _responseHandler.Success(tasks);
    }
}
