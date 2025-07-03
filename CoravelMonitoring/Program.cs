using Coravel;
using CoravelMonitoring;
using CoravelMonitoring.Context;
using CoravelMonitoring.Jobs;
using CoravelMonitoring.Services;
using CoravelMonitoring.Services.JobExecution;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("JobMonitoringDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobExecutionService, JobExecutionService>();
builder.Services.AddScoped<JobMonitoring>();
builder.Services.AddTransient<ExampleJob>();

builder.Services.AddScheduler();

var app = builder.Build();
app.Services.UseScheduler(scheduler => scheduler.ConfigureJobs());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();