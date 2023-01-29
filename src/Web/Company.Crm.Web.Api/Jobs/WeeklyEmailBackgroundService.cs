using Company.Crm.Application.Services.Abstracts;

namespace Company.Crm.Web.Api.Jobs;

public class WeeklyEmailHostedService : BackgroundService //IHostedService, IDisposable
{
    private readonly ILogger<TimedHostedService> _logger;
    private int executionCount = 0;
    private Timer? _timer = null;
    private IServiceScopeFactory _services;

    public WeeklyEmailHostedService(ILogger<TimedHostedService> logger, IServiceScopeFactory services)
    {
        _logger = logger;
        _services = services;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //while (!stoppingToken.IsCancellationRequested)
        //{
            _logger.LogInformation("WeeklyEmail Hosted Service executing.");
            //await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        //}

        return Task.CompletedTask;
    }

    public override Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("WeeklyEmail Hosted Service running.");

        using var scope = _services.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
        var allUsers = userService.GetAll();

        _timer = new Timer(SendEmail, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return base.StartAsync(stoppingToken);
    }

    public override Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return base.StopAsync(stoppingToken);
    }

    private void SendEmail(object? state)
    {
        var count = Interlocked.Increment(ref executionCount);

        // Fire and Forget
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday &&
            DateTime.Now is { Hour: 12, Minute: 0 } && count == 1)
        {
            _logger.LogInformation(
                "Email sending. Count: {Count}", count);
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}