namespace CoravelMonitoring.Context;

using CoravelMonitoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the application's database context,
/// configured to use an in-memory database containing the <see cref="JobExecutionReport"/> entity.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to configure the context.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    /// <summary>
    /// Gets or sets the DbSet representing the monitored job executions in the database.
    /// </summary>
    public DbSet<JobExecutionReport> JobExecutions => Set<JobExecutionReport>();
}
