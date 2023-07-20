using System.Diagnostics;

namespace SimpleBackground.BackgroundServices;
public class SimpleService : BackgroundService
{
    private readonly ILogger<SimpleService> logger;
    public SimpleService(ILogger<SimpleService> logger)
    {
        this.logger = logger;
    }
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var numberOfThreads = Process.GetCurrentProcess().Threads.Count;

        logger.LogInformation($"Task executed. Numer of Threads: {numberOfThreads}");
        await Task.CompletedTask;
    }
}
