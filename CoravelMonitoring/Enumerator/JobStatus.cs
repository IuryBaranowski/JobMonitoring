namespace CoravelMonitoring.Enumerator;

using static CoravelMonitoring.Util.Util;

/// <summary>
/// Represents the status of a job execution.
/// </summary>
public enum JobStatus
{
    /// <summary>
    /// The job is currently running.
    /// </summary>
    [EnumDescription("Running")]
    Running = 1,

    /// <summary>
    /// The job has completed successfully.
    /// </summary>
    [EnumDescription("Completed")]
    Completed = 2,

    /// <summary>
    /// The job has failed.
    /// </summary>
    [EnumDescription("Failed")]
    Failed = 3
}
