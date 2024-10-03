
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TMS.Application.Abstracts.IAuthService;
using TMS.Application.Implementations;

namespace TMS.Application.Extensions;
public static class ModuleApplicationDependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
