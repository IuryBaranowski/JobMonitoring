namespace CoravelMonitoring.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoravelMonitoring.Enumerator;

/// <summary>
/// Represents a record of a job execution report,
/// including its type, start and end times, status, and any error messages.
/// </summary>
[Table("TBJobExecutionReport")]
public class JobExecutionReport
{
    /// <summary>
    /// Gets or sets the unique identifier for the job execution report.
    /// </summary>
    [Key]
    public string Id { get; set; }

    /// <summary>
    /// Gets the type of the job executed.
    /// </summary>
    public JobType JobType { get; private set; }

    /// <summary>
    /// Gets the start time of the job execution.
    /// </summary>
    public DateTimeOffset StartTime { get; private set; }

    /// <summary>
    /// Gets the end time of the job execution, if completed.
    /// </summary>
    public DateTimeOffset? EndTime { get; private set; }

    /// <summary>
    /// Gets the current status of the job execution.
    /// </summary>
    public JobStatus Status { get; private set; }

    /// <summary>
    /// Gets the error message if the job execution failed.
    /// </summary>
    public string ErrorMessage { get; private set; }

    /// <summary>
    /// Parameterless constructor for entity framework and serialization.
    /// </summary>
    public JobExecutionReport() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="JobExecutionReport"/> class with the specified details.
    /// </summary>
    /// <param name="jobType">The type of the job.</param>
    /// <param name="startTime">The start time of the execution.</param>
    /// <param name="endTime">The end time of the execution, if available.</param>
    /// <param name="status">The current status of the job.</param>
    /// <param name="errorMessage">The error message, if any.</param>
    public JobExecutionReport(JobType jobType, DateTimeOffset startTime, DateTimeOffset? endTime, JobStatus status, string errorMessage)
    {
        Id = Guid.NewGuid().ToString();
        JobType = jobType;
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
        ErrorMessage = errorMessage;
    }

    #region Set entities

    /// <summary>
    /// Sets the job type.
    /// </summary>
    /// <param name="jobType">The job type to set.</param>
    public void SetJobType(JobType jobType) => JobType = jobType;

    /// <summary>
    /// Sets the start time.
    /// </summary>
    /// <param name="startTime">The start time to set.</param>
    public void SetStartTime(DateTimeOffset startTime) => StartTime = startTime;

    /// <summary>
    /// Sets the end time.
    /// </summary>
    /// <param name="endTime">The end time to set.</param>
    public void SetEndTime(DateTimeOffset endTime) => EndTime = endTime;

    /// <summary>
    /// Sets the status.
    /// </summary>
    /// <param name="status">The status to set.</param>
    public void SetStatus(JobStatus status) => Status = status;

    /// <summary>
    /// Sets the error message.
    /// </summary>
    /// <param name="errorMessage">The error message to set.</param>
    public void SetErrorMessage(string errorMessage) => ErrorMessage = errorMessage;

    #endregion
}