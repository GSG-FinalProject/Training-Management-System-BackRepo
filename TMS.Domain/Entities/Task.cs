namespace TMS.Domain.Entities;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public Course Course { get; set; }
    public int CourseId { get; set; }
    public ICollection<Submission> Submissions { get; set; }
    public string TrainerId { get; set; } 
    public Trainer Trainer { get; set; }
}