namespace CoravelMonitoring.Services;

using CoravelMonitoring.Enumerator;
using CoravelMonitoring.Services.JobExecution;

/// <summary>
/// Provides a wrapper for executing jobs with monitoring support,
/// automatically handling job start, completion, and failure tracking.
/// </summary>
public class JobMonitoring
{
    private readonly IJobExecutionService _JobExecutionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="JobMonitoring"/> class.
    /// </summary>
    /// <param name="jobExecutionService">The service responsible for managing job execution lifecycle.</param>
    public JobMonitoring(IJobExecutionService jobExecutionService)
    {
        _JobExecutionService = jobExecutionService;
    }

    /// <summary>
    /// Executes the provided job action while monitoring its lifecycle,
    /// recording start, success, or failure in the job execution reports.
    /// </summary>
    /// <param name="jobName">The type of the job being executed.</param>
    /// <param name="jobAction">The asynchronous job action to execute.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="Exception">Re-throws any exception encountered during the job execution.</exception>
    public async Task ExecuteAsync(JobType jobName, Func<Task> jobAction)
    {
        var jobId = await _JobExecutionService.StartJobAsync(jobName);

        try
        {
            await jobAction();
            await _JobExecutionService.CompleteJobAsync(jobId);
        }
        catch (Exception ex)
        {
            await _JobExecutionService.FailJobAsync(jobId, ex.Message);
            throw;
        }
    }
}