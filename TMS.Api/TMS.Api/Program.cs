using TMS.Api.Extensions;
using TMS.Api.Middlewares;
using TMS.Application.Extensions;
using TMS.Infrastructure.Extensions;

namespace TMS.Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddEndpointsApiExplorer()
            .AddApplicationDependencies()
            .AddPresentationDependencies(builder.Configuration)
            .AddInfrastructureDependencies(builder.Configuration)
            .AddSwaggerDocumentation()
            .AddCorsPolicy();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerDocumentation();
        }

        app.UseCors();
        app.UseMiddleware<GlobalExceptionHandling>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}