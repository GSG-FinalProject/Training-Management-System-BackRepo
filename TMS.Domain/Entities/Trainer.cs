namespace TMS.Domain.Entities;
public class Trainer : User
{
    public List<Course> Courses { get; set; } = new List<Course>();
}