namespace TMS.Domain.DTOs.FeedBack;
public class FeedbackResponseDto
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime GivenAt { get; set; }
    public string TrainerName { get; set; }  
    public int SubmissionId { get; set; }
}
