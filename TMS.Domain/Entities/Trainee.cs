namespace TMS.Domain.Entities;
public class Trainee : User
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public String TrainingProgram { get; set; }
    public int TrainingHours { get; set; }
}