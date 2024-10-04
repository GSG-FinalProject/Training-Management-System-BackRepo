namespace TMS.Domain.Entities;
public class Trainer : User
{
    public string Bio { get; set; }
    public int TrainingFieldId { get; set; } 
    public virtual TrainingField TrainingField { get; set; }
    public virtual ICollection<Trainee> Trainees { get; set; }
}