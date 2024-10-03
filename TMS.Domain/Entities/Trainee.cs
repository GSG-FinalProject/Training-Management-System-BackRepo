namespace TMS.Domain.Entities;
public class Trainee : User
{
    public List<Submission> Submissions { get; set; } = new List<Submission>();
}