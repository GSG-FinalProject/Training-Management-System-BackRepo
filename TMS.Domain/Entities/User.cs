using Microsoft.AspNetCore.Identity;
using TMS.Domain.Enums;
namespace TMS.Domain.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role UserType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
