using AutoMapper;
using TMS.Domain.DTOs.FeedBack;
using TMS.Domain.Entities;
namespace TMS.Api.Mapping;
public class FeedbackMappingProfile : Profile
{
    public FeedbackMappingProfile()
    {
        CreateMap<CreateFeedbackRequest, Feedback>();

        CreateMap<UpdateFeedbackRequest, Feedback>();

        CreateMap<Feedback, FeedbackResponseDto>()
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => $"{src.Trainer.FirstName} {src.Trainer.LastName}"));
    }
}
