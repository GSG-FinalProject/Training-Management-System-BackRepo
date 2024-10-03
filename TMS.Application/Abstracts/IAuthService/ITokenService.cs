namespace TMS.Application.Abstracts.IAuthService;
public interface ITokenService
{
    string GenerateToken(User user);
}
