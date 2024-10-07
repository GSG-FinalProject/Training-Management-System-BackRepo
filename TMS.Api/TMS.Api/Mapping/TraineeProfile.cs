using AutoMapper;
using TMS.Domain.DTOs.shared;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;

namespace TMS.Api.Mapping;
public class TraineeProfile : Profile
{
    public TraineeProfile()
    {
        CreateMap<Trainee, TraineeResponseDto>();
    
    CreateMap<UpdateUserDto, Trainer>()
            .ForMember(dest => dest.Bio, opt => opt.Ignore())
            .ForMember(dest => dest.TrainingFieldId, opt => opt.Ignore()); 

    CreateMap<UpdateUserDto, Trainee>()
            .ForMember(dest => dest.TrainerId, opt => opt.Ignore())
            .ForMember(dest => dest.Submissions, opt => opt.Ignore());
}
}