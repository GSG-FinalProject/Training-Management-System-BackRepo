namespace TMS.Domain.DTOs.Course;
public class AddCourseRequest
{
    public string Name { get; set; }
    public string ResourcesUrl { get; set; }
    public string Description { get; set; }
    public int TrainingFieldId { get; set; } 
}
