using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DependencyInjection;

class MyBackgroundService : BackgroundService
{
    readonly ILogger _logger;
    readonly MySingleton _singleton;
    readonly MyTransient _transient;

    public MyBackgroundService(ILogger<MyBackgroundService> logger, MySingleton singleton, MyTransient transient)
    {
        _logger = logger;
        _singleton = singleton;
        _transient = transient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Start");

        _logger.LogInformation("Singleton: {V1} {V2}", _singleton.Valore1, _singleton.Valore2);

        _logger.LogInformation("Transient: {V1} {V2}", _transient.Valore1, _transient.Valore2);

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Loop...");

            await Task.Delay(5000);
        }

        _logger.LogInformation("Stop");
    }
}
