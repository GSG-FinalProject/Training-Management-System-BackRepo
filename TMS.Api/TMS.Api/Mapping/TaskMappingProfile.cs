using AutoMapper;
using TMS.Domain.DTOs.Task;

namespace TMS.Api.Mapping;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<AddTaskRequest, Task>();
        CreateMap<UpdateTaskRequest, Task>();
        CreateMap<Task, TaskResponseDto>();
        CreateMap<Task, TaskResponseDto>();
    }
}
