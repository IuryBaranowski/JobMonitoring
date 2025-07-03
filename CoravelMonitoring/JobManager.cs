namespace CoravelMonitoring;

using Coravel.Scheduling.Schedule.Interfaces;
using CoravelMonitoring.Jobs;

/// <summary>
/// Provides extension methods to configure scheduled jobs using Coravel's scheduler.
/// </summary>
public static class JobManager
{
    /// <summary>
    /// Configures the scheduled jobs on the provided scheduler.
    /// </summary>
    /// <param name="scheduler">The scheduler to configure jobs on.</param>
    public static void ConfigureJobs(this IScheduler scheduler)
    {
        scheduler.Schedule<ExampleJob>().EveryTenSeconds().PreventOverlapping(nameof(ExampleJob)).Once();
    }
}