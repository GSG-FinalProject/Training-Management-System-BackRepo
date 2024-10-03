namespace TMS.Domain.Entities;
public class Trainer : User
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Feedback> Feedbacks { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<Course> Courses { get; set; }
}