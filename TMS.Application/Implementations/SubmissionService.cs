using AutoMapper;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Submission;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using Task = System.Threading.Tasks.Task;

namespace TMS.Application.Implementations;
public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly IMapper _mapper;

    public SubmissionService(ISubmissionRepository submissionRepository, IMapper mapper)
    {
        _submissionRepository = submissionRepository;
        _mapper = mapper;
    }

    public async Task<SubmissionResponseDto> AddAsync(AddSubmissionRequestDto submissionDto)
    {
        var submission = _mapper.Map<Submission>(submissionDto);
        var createdSubmission = await _submissionRepository.AddAsync(submission);
        return _mapper.Map<SubmissionResponseDto>(createdSubmission);
    }

    public async Task DeleteAsync(int submissionId)
    {
        await _submissionRepository.DeleteAsync(submissionId);
    }

    public async Task<IEnumerable<SubmissionResponseDto>> GetAllAsync()
    {
        var submissions = await _submissionRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SubmissionResponseDto>>(submissions);
    }

    public async Task<SubmissionResponseDto> GetByIdAsync(int submissionId)
    {
        var submission = await _submissionRepository.GetByIdAsync(submissionId);
        return _mapper.Map<SubmissionResponseDto>(submission);
    }

    public async Task UpdateAsync(UpdateSubmissionRequestDto submissionDto)
    {
        var submission = _mapper.Map<Submission>(submissionDto);
        await _submissionRepository.UpdateAsync(submission);
    }
}
