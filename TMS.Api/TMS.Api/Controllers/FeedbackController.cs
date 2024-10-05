using Microsoft.AspNetCore.Mvc;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Api.Responses;
using AutoMapper;
using TMS.Domain.DTOs.FeedBack;
using TMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IResponseHandler _responseHandler;
    private readonly IMapper _mapper;

    public FeedbackController(IFeedbackRepository feedbackRepository, IResponseHandler responseHandler, IMapper mapper)
    {
        _feedbackRepository = feedbackRepository;
        _responseHandler = responseHandler;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize(Roles="Trainer")]
    public async Task<IActionResult> CreateFeedback(CreateFeedbackRequest feedbackDto)
    {
        var feedbackEntity = _mapper.Map<Feedback>(feedbackDto);
        var createdFeedback = await _feedbackRepository.AddAsync(feedbackEntity);
        var responseDto = _mapper.Map<FeedbackResponseDto>(createdFeedback);
        return _responseHandler.Created(responseDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        if (feedback == null)
        {
            return _responseHandler.NotFound($"Feedback with ID {id} not found.");
        }

        var responseDto = _mapper.Map<FeedbackResponseDto>(feedback);
        return _responseHandler.Success(responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feedbacks = await _feedbackRepository.GetAllAsync();
        var responseDtos = _mapper.Map<IEnumerable<FeedbackResponseDto>>(feedbacks);
        return _responseHandler.Success(responseDtos);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Trainer")]
    public async Task<IActionResult> UpdateFeedback(int id, UpdateFeedbackRequest feedbackDto)
    {
        var feedbackEntity = _mapper.Map<Feedback>(feedbackDto);
        feedbackEntity.Id = id;

        await _feedbackRepository.UpdateAsync(feedbackEntity);
        return _responseHandler.Success("Update Feedback successfully.");

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Trainer")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        await _feedbackRepository.DeleteAsync(id);
        return _responseHandler.Success("FeedBack deleted successfully.");

    }
}
