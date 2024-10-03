namespace TMS.Domain.Entities;
public class TrainingField
{
    public int TrainingFieldId { get; set; }
    public string TrainingName { get; set; }
    public string TrainingDescription { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}