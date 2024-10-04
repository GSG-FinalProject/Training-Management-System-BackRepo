using AutoMapper;
using TMS.Domain.DTOs.Submission;
using TMS.Domain.Entities;

namespace TMS.Api.Mapping;
public class SubmissionProfile : Profile
{
    public SubmissionProfile()
    {
        CreateMap<AddSubmissionRequestDto, Submission>();
        CreateMap<UpdateSubmissionRequestDto, Submission>();
        CreateMap<Submission, SubmissionResponseDto>();
    }
}