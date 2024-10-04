namespace TMS.Domain.Entities;
public class Feedback
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; } 
    public DateTime GivenAt { get; set; } = DateTime.UtcNow;
    public Trainer Trainer { get; set; }
    public string TrainerId { get; set; }
    public Submission Submission { get; set; }
    public int SubmissionId { get; set; }
}