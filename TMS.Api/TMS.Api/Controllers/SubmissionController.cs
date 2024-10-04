using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Abstracts;
using TMS.Api.Responses;
using TMS.Domain.DTOs.Submission;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionService;
    private readonly IResponseHandler _responseHandler;

    public SubmissionController(ISubmissionService submissionService, IResponseHandler responseHandler)
    {
        _submissionService = submissionService;
        _responseHandler = responseHandler;
    }

    [HttpPost]
    [Authorize(Roles = "Trainee")]
    public async Task<IActionResult> CreateSubmission(AddSubmissionRequestDto submissionDto)
    {
        var createdSubmission = await _submissionService.AddAsync(submissionDto);
        return _responseHandler.Created(createdSubmission, "Submission created successfully.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var submission = await _submissionService.GetByIdAsync(id);
        if (submission is null)
        {
            return _responseHandler.NotFound($"Submission with ID {id} not found.");
        }
        return _responseHandler.Success(submission);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var submissions = await _submissionService.GetAllAsync();
        return _responseHandler.Success(submissions);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubmission(UpdateSubmissionRequestDto submissionDto)
    {
        await _submissionService.UpdateAsync(submissionDto);
        return _responseHandler.NoContent("Submission updated successfully.");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Trainee")]
    public async Task<IActionResult> DeleteSubmission(int id)
    {
        await _submissionService.DeleteAsync(id);
        return _responseHandler.NoContent("Submission deleted successfully.");
    }
}
