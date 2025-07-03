namespace CoravelMonitoring.Controllers;

using CoravelMonitoring.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// API controller responsible for managing job execution reports.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="JobsController"/> class.
    /// </summary>
    /// <param name="context">The database context used to access job execution data.</param>
    public JobsController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all job execution reports, ordered by start time descending.
    /// </summary>
    /// <returns>A list of job execution reports.</returns>
    [HttpGet]
    public async Task<IActionResult> GetExecutions()
    {
        var jobs = await _context.JobExecutions
            .OrderByDescending(j => j.StartTime)
            .ToListAsync();

        return Ok(jobs);
    }
}