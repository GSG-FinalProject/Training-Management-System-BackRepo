using Microsoft.AspNetCore.Identity;
using TMS.Domain.Entities;

namespace TMS.Application.Abstracts.IAuthService;
public interface IUserManager
{
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<User> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
}
