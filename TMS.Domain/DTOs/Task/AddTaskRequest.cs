using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.DTOs.Task;
public class AddTaskRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    public int CourseId { get; set; }
}
