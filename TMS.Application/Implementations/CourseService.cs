
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Course;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;

namespace TMS.Application.Implementations;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> AddCourseAsync(AddCourseRequest request)
    {
        var course = new Course
        {
            Name = request.Name,
            Description = request.Description,
            ResoursesUrl = request.ResourcesUrl,
            TrainingFieldId = request.TrainingFieldId
        };

        await _unitOfWork.CoursesRepository.CreateAsync(course);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateCourseAsync(int id, CourseDto request)
    {
        var course = await _unitOfWork.CoursesRepository.GetByIdAsync(request.Id);
        if (course is null)
        {
            return false; 
        }

        course.Name = request.Name;
        course.Description = request.Description;
        course.ResoursesUrl = request.ResoursesUrl;
        course.TrainingFieldId = request.TrainingFieldId;

        await _unitOfWork.CoursesRepository.UpdateAsync(request.Id,course);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        await _unitOfWork.CoursesRepository.DeleteAsync(courseId);
        return true;
    }

    public async Task<CourseDto> GetCourseByIdAsync(int courseId)
    {
        var course = await _unitOfWork.CoursesRepository.GetByIdAsync(courseId);
        if (course == null)
        {
            return null; 
        }

        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            ResoursesUrl = course.ResoursesUrl,
            Description = course.Description,
            TrainingFieldId = course.TrainingFieldId
        };
    }

    public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
    {
        var courses = await _unitOfWork.CoursesRepository.GetAllAsync();
        var courseDtos = courses.Select(course => new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            ResoursesUrl = course.ResoursesUrl,
            Description = course.Description,
            TrainingFieldId = course.TrainingFieldId
        }).ToList();

        return courseDtos;
    }

}
