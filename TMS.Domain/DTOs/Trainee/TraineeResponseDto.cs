using TMS.Domain.Enums;
namespace TMS.Domain.DTOs.Trainee;
public class TraineeResponseDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Role UserType { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TrainingHours { get; set; }
}