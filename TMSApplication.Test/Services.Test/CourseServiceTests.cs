using Moq;
using TMS.Application.Implementations;
using TMS.Domain.DTOs.Course;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;
using Task = System.Threading.Tasks.Task;
namespace TMSApplication.Test.Services.Test;
public class CourseServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CourseService _courseService;

    public CourseServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _courseService = new CourseService(_mockUnitOfWork.Object);
    }


    [Fact]
    public async Task UpdateCourseAsync_ShouldReturnFalse_WhenCourseNotFound()
    {
        // Arrange
        var courseId = 1;
        var request = new CourseDto { Id = courseId };

        _mockUnitOfWork.Setup(uow => uow.CoursesRepository.GetByIdAsync(courseId)).ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.UpdateCourseAsync(courseId, request);

        // Assert
        Assert.False(result);
        _mockUnitOfWork.Verify(uow => uow.CoursesRepository.GetByIdAsync(courseId), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CoursesRepository.UpdateAsync(It.IsAny<int>(), It.IsAny<Course>()), Times.Never);
        _mockUnitOfWork.Verify(uow => uow.CommitAsync(), Times.Never);
    }

    [Fact]
    public async Task GetCourseByIdAsync_ShouldReturnCourseDto_WhenCourseExists()
    {
        // Arrange
        var courseId = 1;
        var existingCourse = new Course
        {
            Id = courseId,
            Name = "QA Course",
            Description = "Automation Test",
            ResoursesUrl = "http://existing.com",
            TrainingFieldId = 1
        };

        _mockUnitOfWork.Setup(uow => uow.CoursesRepository.GetByIdAsync(courseId)).ReturnsAsync(existingCourse);

        // Act
        var result = await _courseService.GetCourseByIdAsync(courseId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(courseId, result.Id);
        _mockUnitOfWork.Verify(uow => uow.CoursesRepository.GetByIdAsync(courseId), Times.Once);
    }

    [Fact]
    public async Task GetCourseByIdAsync_ShouldReturnNull_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseId = 1;

        _mockUnitOfWork.Setup(uow => uow.CoursesRepository.GetByIdAsync(courseId)).ReturnsAsync((Course)null);

        // Act
        var result = await _courseService.GetCourseByIdAsync(courseId);

        // Assert
        Assert.Null(result);
        _mockUnitOfWork.Verify(uow => uow.CoursesRepository.GetByIdAsync(courseId), Times.Once);
    }

    [Fact]
    public async Task GetAllCoursesAsync_ShouldReturnAllCourseDtos()
    {
        // Arrange
        var courses = new List<Course>
            {
                new Course { Id = 1, Name = "ReactJs", ResoursesUrl = "http://course1.com", Description = "frontend training", TrainingFieldId = 1 },
                new Course { Id = 2, Name = "Angular", ResoursesUrl = "http://course2.com", Description = "frontend training", TrainingFieldId = 2 }
            };

        _mockUnitOfWork.Setup(uow => uow.CoursesRepository.GetAllAsync()).ReturnsAsync(courses);

        // Act
        var result = await _courseService.GetAllCoursesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        _mockUnitOfWork.Verify(uow => uow.CoursesRepository.GetAllAsync(), Times.Once);
    }
}
