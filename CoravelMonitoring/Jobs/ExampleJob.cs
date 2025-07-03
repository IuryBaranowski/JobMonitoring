using Coravel.Invocable;
using CoravelMonitoring.Enumerator;
using CoravelMonitoring.Services;

namespace CoravelMonitoring.Jobs
{
    /// <summary>
    /// A sample job that demonstrates the usage of the job monitoring system.
    /// </summary>
    public class ExampleJob : IInvocable
    {
        private readonly JobMonitoring _monitor;
        private readonly ILogger<ExampleJob> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleJob"/> class.
        /// </summary>
        /// <param name="monitor">The job monitoring service used to track execution.</param>
        /// <param name="logger">The logger instance for logging job execution details.</param>
        public ExampleJob(JobMonitoring monitor, ILogger<ExampleJob> logger)
        {
            _monitor = monitor;
            _logger = logger;
        }

        /// <summary>
        /// Executes the example job, logging start and finish messages, and simulating work with a delay.
        /// </summary>
        public async Task Invoke()
        {
            await _monitor.ExecuteAsync(JobType.Example, async () =>
            {
                _logger.LogInformation("ExampleJob started...");

                await Task.Delay(3000);

                _logger.LogInformation("ExampleJob finished!");
            });
        }
    }
}
