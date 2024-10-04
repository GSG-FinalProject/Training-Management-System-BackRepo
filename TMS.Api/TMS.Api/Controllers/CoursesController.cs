
using Microsoft.AspNetCore.Mvc;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Course;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // POST: api/courses
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] AddCourseRequest request)
    {
        if (request == null)
        {
            return BadRequest(new { message = "Invalid course data." });
        }

        try
        {
            var result = await _courseService.AddCourseAsync(request);
            return result ? Ok(new { message = "Course added successfully." }) : BadRequest(new { message = "Failed to add course." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while adding the course.", details = ex.Message });
        }
    }

    // PUT: api/courses/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto request)
    {
        if (request == null || id <= 0)
        {
            return BadRequest(new { message = "Invalid course data or ID." });
        }

        try
        {
            var result = await _courseService.UpdateCourseAsync(id, request);
            return result ? Ok(new { message = "Course updated successfully." }) : NotFound(new { message = "Course not found." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the course.", details = ex.Message });
        }
    }

    // DELETE: api/courses/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "Invalid course ID." });
        }

        try
        {
            var result = await _courseService.DeleteCourseAsync(id);
            return result ? Ok(new { message = "Course deleted successfully." }) : NotFound(new { message = "Course not found." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while deleting the course.", details = ex.Message });
        }
    }

    // GET: api/courses
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        try
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving courses.", details = ex.Message });
        }
    }

    // GET: api/courses/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new { message = "Invalid course ID." });
        }

        try
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return course != null ? Ok(course) : NotFound(new { message = "Course not found." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the course.", details = ex.Message });
        }
    }
}