using Microsoft.Extensions.DependencyInjection;
using TMS.Application.Abstracts.IAuthService;
using TMS.Application.Implementations;
using TMS.Application.Abstracts;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Application.Extensions;
public static class ModuleApplicationDependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITraineeService, TraineeService>();
        services.AddScoped<ITrainingFieldService, TrainingFieldService>();
        services.AddScoped<ITaskService, TaskService>();
       
        return services;
    }
}
