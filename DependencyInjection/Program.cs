using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Vedere documentazione Microsoft:
// https://learn.microsoft.com/dotnet/core/extensions/generic-host

// crea un builder utilizzabile per configurare un host
IHostBuilder builder = Host.CreateDefaultBuilder(args);

// configura i servizi disponibili
builder.ConfigureServices((hostContext, services) =>
{
    // servizio con start e stop
    services.AddHostedService<MyHostedService>();

    // servizio con ciclo infinito
    services.AddHostedService<MyBackgroundService>();

    // singleton (una sola istanza globale)
    services.AddSingleton(new MySingleton { Valore1 = Random.Shared.Next(), Valore2 = "singleton" });

    // transient (uno nuovo per ogni richiesta)
    services.AddTransient(services =>
    {
        return new MyTransient { Valore1 = Random.Shared.Next(), Valore2 = "transient" };
    });
});

// costruisce l'host configurato
IHost host = builder.Build();

// esegue l'host costruito
host.Run();
