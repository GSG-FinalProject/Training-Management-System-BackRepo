namespace TMS.Domain.Entities;
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TrainingField TrainingField { get; set; }
    public int TrainingFieldId { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public Trainer Trainer { get; set; }
    public string TrainerId { get; set; }
    public ICollection<Trainee> Trainees { get; set; }
}