using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DependencyInjection;

class MyHostedService : IHostedService
{
    readonly ILogger _logger;
    readonly MySingleton _singleton;
    readonly MyTransient _transient;

    public MyHostedService(ILogger<MyHostedService> logger, MySingleton singleton, MyTransient transient)
    {
        _logger = logger;
        _singleton = singleton;
        _transient = transient;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start");

        _logger.LogInformation("Singleton: {V1} {V2}", _singleton.Valore1, _singleton.Valore2);

        _logger.LogInformation("Transient: {V1} {V2}", _transient.Valore1, _transient.Valore2);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stop");

        return Task.CompletedTask;
    }
}
