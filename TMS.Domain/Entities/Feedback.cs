namespace TMS.Domain.Entities;
public class Feedback
{
    public int Id { get; set; }
    public int SubmissionId { get; set; }
    public string Comments { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public string TrainerId { get; set; }
    public Trainer Trainer { get; set; }
    public string TraineeId { get; set; }
    public Trainee Trainee { get; set; }
}