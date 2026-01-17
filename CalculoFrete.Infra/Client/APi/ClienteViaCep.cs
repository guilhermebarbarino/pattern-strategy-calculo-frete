using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Modelos;
using CalculoFrete.Infra.Cache.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace CalculoFrete.Infra.Client.APi;

public sealed class ClienteViaCep : IConsultaCep
{
    private static readonly TimeSpan TempoDeVidaCache = TimeSpan.FromHours(6);

    private readonly HttpClient _httpClient;
    private readonly ICacheCep _cache;

    public ClienteViaCep(HttpClient httpClient, ICacheCep cache)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<EnderecoCep?> ConsultarAsync(string cep, CancellationToken cancellationToken)
    {
        if (!CepTemFormatoBasicoValido(cep))
            return null;

        if (_cache.TentarObter(cep, out var enderecoDoCache))
            return enderecoDoCache;

        try
        {
            var resposta = await _httpClient.GetAsync($"/ws/{cep}/json/", cancellationToken);

            if (resposta.StatusCode == HttpStatusCode.BadRequest)
                return null;

            resposta.EnsureSuccessStatusCode();

            var dto = await resposta.Content.ReadFromJsonAsync<ViaCepResposta>(cancellationToken: cancellationToken);

            if (dto is null || dto.Erro == true)
                return null;

            if (string.IsNullOrWhiteSpace(dto.Cep) ||
                string.IsNullOrWhiteSpace(dto.Localidade) ||
                string.IsNullOrWhiteSpace(dto.Uf))
                return null;

            var endereco = new EnderecoCep(
                cep: dto.Cep,
                cidade: dto.Localidade,
                uf: dto.Uf,
                logradouro: dto.Logradouro,
                bairro: dto.Bairro);

            _cache.Salvar(cep, endereco, TempoDeVidaCache);
            return endereco;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    private static bool CepTemFormatoBasicoValido(string cep)
        => cep.Length == 8 && cep.All(char.IsDigit);

    private sealed class ViaCepResposta
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public bool? Erro { get; set; }
    }
}
