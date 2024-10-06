namespace TMS.Domain.DTOs.Task;
public class UpdateTaskRequest
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}
