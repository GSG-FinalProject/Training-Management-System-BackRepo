using TMS.Domain.DTOs.Submission;

namespace TMS.Application.Abstracts;
public interface ISubmissionService
{
    Task<SubmissionResponseDto> AddAsync(AddSubmissionRequestDto submissionDto);
    Task UpdateAsync(UpdateSubmissionRequestDto submissionDto);
    Task DeleteAsync(int submissionId);
    Task<SubmissionResponseDto> GetByIdAsync(int submissionId);
    Task<IEnumerable<SubmissionResponseDto>> GetAllAsync();
}
