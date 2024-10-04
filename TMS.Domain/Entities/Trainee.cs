namespace TMS.Domain.Entities;
public class Trainee : User
{
    public ICollection<Submission> Submissions { get; set; }
    public string TrainerId { get; set; }  
    public Trainer Trainer { get; set; }
}