using TMS.Domain.Enums;

namespace TMS.Domain.DTOs.shared;
public class LoginResponseDto
{
    public string Token { get; set; }
    public Role UserType { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}