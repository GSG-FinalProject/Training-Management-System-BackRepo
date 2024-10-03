namespace TMS.Domain.Entities;
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int TrainingFieldId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Url { get; set; }
    public string TrainerId { get; set; }
    public TrainingField TrainingField { get; set; }
    public List<Task> Assignments { get; set; } = new List<Task>();

}
