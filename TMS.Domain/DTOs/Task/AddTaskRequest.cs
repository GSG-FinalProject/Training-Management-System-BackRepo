namespace TMS.Domain.DTOs.Task;
public class AddTaskRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int CourseId { get; set; }
}