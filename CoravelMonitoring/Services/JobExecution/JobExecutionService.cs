namespace CoravelMonitoring.Services.JobExecution;

using CoravelMonitoring.Context;
using CoravelMonitoring.Data.Entities;
using CoravelMonitoring.Enumerator;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Implements the <see cref="IJobExecutionService"/> interface to manage job execution lifecycle,
/// persisting execution reports to the database.
/// </summary>
public class JobExecutionService : IJobExecutionService
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="JobExecutionService"/> class.
    /// </summary>
    /// <param name="context">The database context used to persist job execution reports.</param>
    public JobExecutionService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Starts a new job execution by creating a report with status "Running".
    /// </summary>
    /// <param name="jobType">The type of job being started.</param>
    /// <returns>A task representing the asynchronous operation, returning the execution ID.</returns>
    public async Task<string> StartJobAsync(JobType jobType)
    {
        var report = new JobExecutionReport(jobType, DateTimeOffset.Now, null, JobStatus.Running, null);

        await _context.JobExecutions.AddAsync(report);
        await _context.SaveChangesAsync();

        return report.Id;
    }

    /// <summary>
    /// Marks an existing job execution as completed, setting its end time and status.
    /// </summary>
    /// <param name="executionId">The unique identifier of the job execution to complete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CompleteJobAsync(string executionId)
    {
        var report = await _context.JobExecutions.FirstOrDefaultAsync(x => x.Id == executionId);

        if (report is not null)
        {
            report.SetEndTime(DateTimeOffset.Now);
            report.SetStatus(JobStatus.Completed);

            _context.JobExecutions.Update(report);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Marks an existing job execution as failed, setting its end time, status, and error message.
    /// </summary>
    /// <param name="executionId">The unique identifier of the job execution that failed.</param>
    /// <param name="errorMessage">The error message explaining the failure.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task FailJobAsync(string executionId, string errorMessage)
    {
        var report = await _context.JobExecutions.FirstOrDefaultAsync(x => x.Id == executionId);

        if (report is not null)
        {
            report.SetEndTime(DateTimeOffset.Now);
            report.SetStatus(JobStatus.Failed);
            report.SetErrorMessage(errorMessage);

            _context.JobExecutions.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}