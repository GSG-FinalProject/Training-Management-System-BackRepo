using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Course;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IResponseHandler _responseHandler;

    public CoursesController(ICourseService courseService, IResponseHandler responseHandler)
    {
        _courseService = courseService;
        _responseHandler = responseHandler;
    }

    [HttpPost("add")]
    [Authorize(Roles = "Trainer")]
    public async Task<IActionResult> AddCourse([FromBody] AddCourseRequest request)
    {
        if (request is null)
        {
            return _responseHandler.BadRequest("Invalid course data.");
        }

        try
        {
            var result = await _courseService.AddCourseAsync(request);
            if (result)
            {
                return _responseHandler.Success("Course added successfully.");
            }
            return _responseHandler.BadRequest("Failed to add the course.");
        }
        catch (Exception ex)
        {
            return _responseHandler.UnprocessableEntity($"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        try
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course is null)
            {
                return _responseHandler.NotFound("Course not found.");
            }

            return _responseHandler.Success(course, "Course retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.UnprocessableEntity($"An error occurred: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourse()
    {
        try
        {
            var course = await _courseService.GetAllCoursesAsync();
            if (course is null)
            {
                return _responseHandler.NotFound("Courses not found.");
            }

            return _responseHandler.Success(course, "Courses retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.UnprocessableEntity($"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Trainer")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto request)
    {
        if (request is null)
        {
            return _responseHandler.BadRequest("Invalid course data.");
        }

        try
        {
            var result = await _courseService.UpdateCourseAsync(id, request);
            if (result)
            {
                return _responseHandler.Success("Course updated successfully.");
            }
            return _responseHandler.NotFound("Course not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.UnprocessableEntity($"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Trainer")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        try
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (result)
            {
                return _responseHandler.Success("Course deleted successfully.");
            }
            return _responseHandler.NotFound("Course not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.UnprocessableEntity($"An error occurred: {ex.Message}");
        }
    }
}
