using AutoMapper;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;

namespace TMS.Api.Mapping;
public class TrainerProfile : Profile
{
    public TrainerProfile()
    {
        CreateMap<Trainer, TrainerResponseDto>();
    }
}