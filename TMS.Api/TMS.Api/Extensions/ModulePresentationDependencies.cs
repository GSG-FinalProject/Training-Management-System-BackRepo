using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TMS.Api.Logger;
using TMS.Api.Responses;
using TMS.Application.Abstracts.IAuthService;
using TMS.Application.Implementations;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.ILogger;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
using TMS.Infrastructure.Repositories;

namespace TMS.Api.Extensions;
public static class ModulePresentationDependencies
{
    public static IServiceCollection AddPresentationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);

        services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<IResponseHandler, ResponseHandler>();

        services.AddScoped<IUserManager, UserManager>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                    };
                });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        });

        services.AddControllers(options =>
        {
            options.CacheProfiles.Add("DefaultCache", new CacheProfile
            {
                Duration = 30,
                Location = ResponseCacheLocation.Any
            });
        });

        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddScoped<ILog, Log>();
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<IResponseHandler, ResponseHandler>();
        services.AddScoped<ITraineeRepository, TraineeRepository>();

        return services;
    }
}