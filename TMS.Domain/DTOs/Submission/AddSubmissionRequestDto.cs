
namespace TMS.Domain.DTOs.Submission;
public class AddSubmissionRequestDto
{
    public string FilePath { get; set; }
    public string TraineeId { get; set; }
    public int TaskId { get; set; }
}