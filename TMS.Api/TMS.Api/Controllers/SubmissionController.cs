using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Submission;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpPost]
    public async Task<ActionResult<SubmissionResponseDto>> CreateSubmission(AddSubmissionRequestDto submissionDto)
    {
        var createdSubmission = await _submissionService.AddAsync(submissionDto);
        return CreatedAtAction(nameof(GetById), new { id = createdSubmission.Id }, createdSubmission);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubmissionResponseDto>> GetById(int id)
    {
        var submission = await _submissionService.GetByIdAsync(id);
        if (submission is null)
        {
            return NotFound();
        }
        return Ok(submission);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubmissionResponseDto>>> GetAll()
    {
        var submissions = await _submissionService.GetAllAsync();
        return Ok(submissions);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubmission(UpdateSubmissionRequestDto submissionDto)
    {
        await _submissionService.UpdateAsync(submissionDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubmission(int id)
    {
        await _submissionService.DeleteAsync(id);
        return NoContent();
    }
}
