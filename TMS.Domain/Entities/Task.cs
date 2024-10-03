namespace TMS.Domain.Entities;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int CourseId { get; set; }
    public List<Submission> Submissions { get; set; } = new List<Submission>();
}
