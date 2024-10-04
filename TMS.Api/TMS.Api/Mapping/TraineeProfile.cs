using AutoMapper;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;

namespace TMS.Api.Mapping;
public class TraineeProfile : Profile
{
    public TraineeProfile()
    {
        CreateMap<Trainee, TraineeResponseDto>();
    }
}
