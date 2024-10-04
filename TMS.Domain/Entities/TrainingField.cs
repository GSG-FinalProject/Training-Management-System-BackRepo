namespace TMS.Domain.Entities;
public class TrainingField
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}