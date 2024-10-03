namespace TMS.Domain.Entities;
public class Submission
{
    public int SubmissionId { get; set; }   
    public int AssignmentId { get; set; }     
    public string TraineeId { get; set; }       
    public DateTime SubmissionDate { get; set; }
}
