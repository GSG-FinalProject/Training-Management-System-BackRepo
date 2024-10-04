using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.TrainingField;
namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingFieldController : ControllerBase
{
    private readonly ITrainingFieldService _trainingFieldService;
    private readonly IResponseHandler _responseHandler;

    public TrainingFieldController(ITrainingFieldService trainingFieldService, IResponseHandler responseHandler)
    {
        _trainingFieldService = trainingFieldService;
        _responseHandler = responseHandler;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var trainingField = await _trainingFieldService.GetByIdAsync(id);
        if (trainingField == null)
        {
            return _responseHandler.NotFound("Training field not found.");
        }
        return _responseHandler.Success(trainingField);
    }

    [HttpPost]
   // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] AddTrainingFieldDto trainingFieldDto)
    {
        var trainingField = await _trainingFieldService.CreateAsync(trainingFieldDto);
        return _responseHandler.Created(trainingField, "Training field created successfully.");
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AddTrainingFieldDto trainingFieldDto)
    {
        try
        {
            await _trainingFieldService.UpdateAsync(id, trainingFieldDto);
            return _responseHandler.NoContent("Training field updated successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound("Training field not found.");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _trainingFieldService.DeleteAsync(id);
        if (result == "Entity deleted successfully.")
        {
            return _responseHandler.NoContent("Training field deleted successfully.");
        }
        return _responseHandler.NotFound("Training field not found.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var trainingFields = await _trainingFieldService.GetAllAsync();
        return _responseHandler.Success(trainingFields);
    }
}