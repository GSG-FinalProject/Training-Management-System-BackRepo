using TMS.Domain.Enums;
namespace TMS.Domain.DTOs.Admin;
public class AdminResponseDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public Role UserType { get; set; }
    public DateTime CreatedAt { get; set; }
}