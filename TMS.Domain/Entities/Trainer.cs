namespace TMS.Domain.Entities;
public class Trainer : User
{
    public string Bio { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Trainee> Trainees { get; set; }
}