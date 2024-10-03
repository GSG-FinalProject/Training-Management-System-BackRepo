using TMS.Domain.Enums;
namespace TMS.Domain.DTOs.Trainer;
public class TrainerResponseDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Role UserType { get; set; }
    public DateTime CreatedAt { get; set; }
}