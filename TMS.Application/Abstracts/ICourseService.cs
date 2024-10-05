using TMS.Domain.DTOs.Course;
using TMS.Domain.Entities;
namespace TMS.Application.Abstracts;
public interface ICourseService
{
    Task<bool> AddCourseAsync(AddCourseRequest request);
    Task<bool> UpdateCourseAsync(int id , CourseDto request); 
    Task<bool> DeleteCourseAsync(int courseId);
    Task<CourseDto> GetCourseByIdAsync(int courseId); 
    Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
}