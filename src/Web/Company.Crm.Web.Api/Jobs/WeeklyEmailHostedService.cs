using Company.Crm.Application.Services.Abstracts;

namespace Company.Crm.Web.Api.Jobs;

public class WeeklyEmailHostedService : IHostedService, IDisposable
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

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("WeeklyEmail Hosted Service running.");

        using var scope = _services.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
        var allUsers = userService.GetAll();

        _timer = new Timer(SendEmail, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private void SendEmail(object? state)
    {
        var count = Interlocked.Increment(ref executionCount);

        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday &&
            DateTime.Now.Hour == 12 && DateTime.Now.Minute == 0 && count == 1)
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
