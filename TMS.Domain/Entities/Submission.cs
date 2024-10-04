namespace TMS.Domain.Entities;
public class Submission
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public DateTime SubmittedAt { get; set; }
    public Trainee Trainee { get; set; }
    public string TraineeId { get; set; }
    public Task Task { get; set; }
    public int TaskId { get; set; }
    public Feedback Feedback { get; set; }
}