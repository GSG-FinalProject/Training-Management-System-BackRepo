namespace TMS.Domain.DTOs.FeedBack;
public class UpdateFeedbackRequest
{
    public string Comment { get; set; }
    public int Rating { get; set; }
    public string TrainerId { get; set; }
    public int SubmissionId { get; set; }
}
