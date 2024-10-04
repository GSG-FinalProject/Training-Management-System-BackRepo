namespace TMS.Domain.DTOs.Submission;
public class SubmissionResponseDto
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string TraineeId { get; set; }
    public int TaskId { get; set; }
}