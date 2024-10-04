using System.Data;
using TMS.Application.Abstracts.IAuthService;
using TMS.Domain.DTOs.Admin;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;
using TMS.Domain.Enums;
using TMS.Domain.Interfaces.ILogger;

namespace TMS.Application.Implementations;
public class AuthService : IAuthService
{
    private readonly IUserManager _userManager;
    private readonly ITokenService _tokenService;
    private readonly ILog _log;

    public AuthService(IUserManager userManager, ITokenService tokenService, ILog log)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _tokenService = tokenService;
        _log = log;
    }

    public async Task<AdminResponseDto> RegisterAdminAsync(RegisterAdminDto registerAdminDto)
    {
        var admin = new Admin
        {
            Email = registerAdminDto.Email,
            UserName = registerAdminDto.Email,
            UserType = Role.Admin,
            FirstName = registerAdminDto.FirstName,
            LastName = registerAdminDto.LastName
        };

        var result = await _userManager.CreateAsync(admin, registerAdminDto.Password);
        if (result.Succeeded)
        {
            return new AdminResponseDto
            {
                Id = admin.Id,
                Email = admin.Email,
                UserType = admin.UserType.ToString(),
                CreatedAt = DateTime.UtcNow
            };
        }

        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"Failed to register admin: {errors}");
    }


    public async Task<TrainerResponseDto> RegisterTrainerAsync(RegisterTrainerDto registerTrainerDto)
    {
        var trainer = new Trainer
        {
            Email = registerTrainerDto.Email,
            UserName = registerTrainerDto.Email,
            UserType = Role.Trainer,
            FirstName = registerTrainerDto.FirstName,
            LastName = registerTrainerDto.LastName,
            Bio = registerTrainerDto.Bio,
            TrainingFieldId=registerTrainerDto.TrainingFieldId
        };

        var result = await _userManager.CreateAsync(trainer, registerTrainerDto.Password);
        if (result.Succeeded)
        {
            return new TrainerResponseDto
            {
                Id = trainer.Id,
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                UserType = trainer.UserType.ToString(),
                CreatedAt = trainer.CreatedAt
            };
        }

        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"Failed to register Trainer: {errors}");
    }

    public async Task<TraineeResponseDto> RegisterTraineeAsync(RegisterTraineeDto registerTraineeDto)
    {
        var trainee = new Trainee
        {
            Email = registerTraineeDto.Email,
            UserName = registerTraineeDto.Email,
            UserType = Role.Trainee,
            FirstName = registerTraineeDto.FirstName,
            LastName = registerTraineeDto.LastName,
            TrainerId = registerTraineeDto.TrainerId
        };

        var result = await _userManager.CreateAsync(trainee, registerTraineeDto.Password);
        if (result.Succeeded)
        {
            return new TraineeResponseDto
            {
                Id = trainee.Id,
                Email = trainee.Email,
                FirstName = trainee.FirstName,
                LastName = trainee.LastName,
                UserType = trainee.UserType.ToString(),
                CreatedAt = trainee.CreatedAt,
            };
        }

        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"Failed to register Trainee: {errors}");
    }
}
