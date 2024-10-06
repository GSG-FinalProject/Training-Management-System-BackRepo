namespace TMS.Domain.Entities;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ResoursesUrl { get; set; }
    public string Description { get; set; }
    public int TrainingFieldId { get; set; }
    public virtual TrainingField TrainingField { get; set; }
}