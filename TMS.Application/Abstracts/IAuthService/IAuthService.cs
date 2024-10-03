using TMS.Domain.DTOs.Admin;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.DTOs.Trainer;

namespace TMS.Application.Abstracts.IAuthService;
public interface IAuthService
{
    Task<AdminResponseDto> RegisterAdminAsync(RegisterAdminDto registerAdminDto);
    Task<TrainerResponseDto> RegisterTrainerAsync(RegisterTrainerDto registerTrainerDto);
    Task<TraineeResponseDto> RegisterTraineeAsync(RegisterTraineeDto registerTraineeDto);

}