using CalculoFrete.Aplicacao.Interfaces;
using CalculoFrete.Aplicacao.Services;
using CalculoFrete.ConsoleApp.UI;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Infra.Cache;
using CalculoFrete.Infra.Cache.Interfaces;
using CalculoFrete.Infra.Client.APi;
using CalculoFrete.Infra.Strategy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<ServicoCalculoFrete>();
        services.AddSingleton<ServicoCalculoFreteComEndereco>();

        services.AddSingleton<IEstrategiaCalculoFrete, EstrategiaRetiradaNaLoja>();
        services.AddSingleton<IEstrategiaCalculoFrete, EstrategiaFreteExpresso>();
        services.AddSingleton<IEstrategiaCalculoFrete, EstrategiaFreteEconomico>();

        services.AddSingleton<ICacheCep, CacheCepInMemory>();

        services.AddHttpClient<IConsultaCep, ClienteViaCep>(client =>
        {
            client.BaseAddress = new Uri("https://viacep.com.br");
            client.Timeout = TimeSpan.FromSeconds(5);
        });

        services.AddSingleton<ILeitorConsole, LeitorConsole>();
        services.AddSingleton<IFormatadorConsole, FormatadorConsole>();
        services.AddSingleton<MenuConsole>();
    })
    .Build();

await host.Services.GetRequiredService<MenuConsole>().ExecutarAsync();
