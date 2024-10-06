using Microsoft.AspNetCore.Mvc;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Api.Responses; 

namespace TMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IResponseHandler _responseHandler;

    public FeedbackController(IFeedbackRepository feedbackRepository, IResponseHandler responseHandler)
    {
        _feedbackRepository = feedbackRepository;
        _responseHandler = responseHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeedback(Feedback feedback)
    {
        var createdFeedback = await _feedbackRepository.CreateAsync(feedback);
        return _responseHandler.Created(createdFeedback);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        if (feedback == null)
        {
            return _responseHandler.NotFound($"Feedback with ID {id} not found.");
        }
        return _responseHandler.Success(feedback);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feedbacks = await _feedbackRepository.GetAllAsync();
        return _responseHandler.Success(feedbacks);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeedback(int id, Feedback feedback)
    {
        if (id != feedback.Id)
        {
            return _responseHandler.BadRequest("ID mismatch.");
        }

        await _feedbackRepository.UpdateAsync(id,feedback);
        return _responseHandler.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        await _feedbackRepository.DeleteAsync(id);
        return _responseHandler.NoContent();
    }
}
