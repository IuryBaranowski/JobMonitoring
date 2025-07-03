namespace CoravelMonitoring.Services.JobExecution;

using CoravelMonitoring.Enumerator;

/// <summary>
/// Defines the contract for services that manage the lifecycle of job executions,
/// including starting, completing, and failing jobs.
/// </summary>
public interface IJobExecutionService
{
    /// <summary>
    /// Starts a new job execution and returns its unique identifier.
    /// </summary>
    /// <param name="jobType">The type of the job being started.</param>
    /// <returns>A task that represents the asynchronous operation, containing the execution ID.</returns>
    Task<string> StartJobAsync(JobType jobType);

    /// <summary>
    /// Marks the specified job execution as completed.
    /// </summary>
    /// <param name="executionId">The unique identifier of the job execution to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CompleteJobAsync(string executionId);

    /// <summary>
    /// Marks the specified job execution as failed, recording an error message.
    /// </summary>
    /// <param name="executionId">The unique identifier of the job execution that failed.</param>
    /// <param name="errorMessage">The error message describing the failure.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task FailJobAsync(string executionId, string errorMessage);
}