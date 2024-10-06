using AutoMapper;
using TMS.Domain.DTOs.Task;
using TMS.Domain.Entities;

namespace TMS.Api.Mapping;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<AddTaskRequest, Domain.Entities.Task>()
            .ForMember(dest => dest.Submissions, opt => opt.Ignore())
            .ForMember(dest => dest.Course, opt => opt.Ignore());

        CreateMap<UpdateTaskRequest, Domain.Entities.Task>();

        CreateMap<Domain.Entities.Task, TaskResponseDto>();
    }
}
