using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;
using TMS.Infrastructure.DbContexts;
using Task = System.Threading.Tasks.Task;

namespace TMS.Infrastructure.Repositories;

public class SubmissionRepository : ISubmissionRepository
{
    private readonly AppDbContext _context;

    public SubmissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Submission> AddAsync(Submission submission)
    {
        await _context.Submissions.AddAsync(submission);
        await _context.SaveChangesAsync();
        return submission;
    }

    public async Task UpdateAsync(Submission submission)
    {
        _context.Submissions.Update(submission);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int submissionId)
    {
        var submission = await GetByIdAsync(submissionId);
        if (submission != null)
        {
            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Submission not found");
        }
    }

    public async Task<Submission> GetByIdAsync(int submissionId)
    {
        return await _context.Submissions.FindAsync(submissionId);
    }

    public async Task<IEnumerable<Submission>> GetAllAsync()
    {
        return await _context.Submissions.ToListAsync();
    }
}
