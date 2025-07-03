# Job Monitoring with Coravel and .NET 8
This project demonstrates a custom job monitoring system built on top of Coravel in a .NET 8 Web API. It provides tracking and logging of background job executions including their start, success, failure, and duration — without relying on paid Coravel monitoring features.

# Features
- Uses Coravel for scheduling background jobs
- Tracks job execution lifecycle (start, complete, fail) in an in-memory database via EF Core
- Provides an API endpoint to retrieve job execution reports
- Implements a reusable JobMonitoring service to wrap any job logic with monitoring
- Includes an example job that logs messages and simulates work

# Getting Started
## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 / VS Code or any C# IDE

## Installation
1. Clone this repository:

```
git clone https://github.com/IuryBaranowski/JobMonitoring.git
cd job-monitoring
```

2. Build and run the project:
```
dotnet run
```

3. The API will be available at https://localhost:<port>/api/jobs

## Usage
- The example job runs automatically every 10 seconds (configured via Coravel Scheduler).
- Job execution data is stored in an EF Core in-memory database.
- Query executed jobs via HTTP GET:

```
GET https://localhost:<port>/api/jobs
```
It returns a list of job execution reports ordered by start time descending.

## Project Structure
- Jobs: Contains Coravel jobs, e.g., ExampleJob.
Services: Implements job execution lifecycle management (JobExecutionService, JobMonitoring).
- Context: EF Core AppDbContext definition with JobExecutionReport entity.
- Controllers: API controller exposing job execution reports.
- Enumerator: Enums for job types and statuses.
- JobManager: Extension class to configure scheduled jobs with Coravel.

## How It Works
1. When a job runs, it calls JobMonitoring.ExecuteAsync() passing a delegate with the job logic.
2. JobMonitoring uses JobExecutionService to create a new job execution report with status Running.
3. The job action executes; if successful, the status updates to Completed; if an exception occurs, it updates to Failed with the error message.
4. All data is stored in the in-memory EF Core database, accessible through the API.

## Extending
- Add more job types to the JobType enum.
- Implement additional jobs using the IInvocable interface and wrap them with JobMonitoring.
- Swap EF Core InMemory provider for a persistent database by changing AppDbContext setup.

## License
MIT License. Feel free to use and modify.
