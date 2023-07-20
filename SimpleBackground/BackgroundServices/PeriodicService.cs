using System.Diagnostics;

namespace SimpleBackground.BackgroundServices;
public class PeriodicService : BackgroundService
{
    private readonly ILogger<PeriodicService> logger;
    private readonly TimeSpan period = TimeSpan.FromSeconds(5);
    public PeriodicService(ILogger<PeriodicService> logger)
    {
        this.logger = logger;
    }
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(period);

        while (!stoppingToken.IsCancellationRequested &&
               await timer.WaitForNextTickAsync(stoppingToken))
        {
            logger.LogInformation("Executing PeriodicBackgroundTask");
        }
    }
}
