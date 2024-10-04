using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.shared;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly ITraineeService _traineeService;

        public AssignmentController(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignTrainerToTrainee([FromBody] AssignTrainerTraineeDto assignDto)
        {
            try
            {
                await _traineeService.AssignTrainerToTraineeAsync(assignDto);
                return Ok(new { message = "Trainer assigned to trainee successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while assigning the trainer to the trainee.", details = ex.Message });
            }
        }
    }
}
