using TMS.Domain.DTOs.shared;
namespace TMS.Application.Abstracts;
public interface ITraineeService
{
    Task AssignTrainerToTraineeAsync(AssignTrainerTraineeDto assignDto);
}