using CalculoFrete.Dominio.Erros;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Modelos;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Aplicacao.Services;

public sealed class ServicoCalculoFreteComEndereco
{
    private readonly ServicoCalculoFrete _servicoCalculoFrete;
    private readonly IConsultaCep _consultaCep;

    public ServicoCalculoFreteComEndereco(ServicoCalculoFrete servicoCalculoFrete, IConsultaCep consultaCep)
    {
        _servicoCalculoFrete = servicoCalculoFrete ?? throw new ArgumentNullException(nameof(servicoCalculoFrete));
        _consultaCep = consultaCep ?? throw new ArgumentNullException(nameof(consultaCep));
    }

    public async Task<ResultadoCalculoFrete> CalcularAsync(SolicitacaoFrete solicitacao, CancellationToken cancellationToken)
    {
        if (solicitacao is null) throw new ArgumentNullException(nameof(solicitacao));

        var cepOrigem = NormalizarCep(solicitacao.CepOrigem);
        var cepDestino = NormalizarCep(solicitacao.CepDestino);

        if (!CepTemFormatoBasicoValido(cepOrigem))
            throw new ErroValidacaoFrete("CEP de origem inválido. Use 8 dígitos (ex.: 01001000).");

        if (!CepTemFormatoBasicoValido(cepDestino))
            throw new ErroValidacaoFrete("CEP de destino inválido. Use 8 dígitos (ex.: 01001000).");

        var origem = await _consultaCep.ConsultarAsync(cepOrigem, cancellationToken);
        if (origem is null)
            throw new ErroValidacaoFrete("Não foi possível validar o CEP de origem. Verifique o CEP ou tente novamente (API de CEP indisponível).");

        var destino = await _consultaCep.ConsultarAsync(cepDestino, cancellationToken);
        if (destino is null)
            throw new ErroValidacaoFrete("Não foi possível validar o CEP de destino. Verifique o CEP ou tente novamente (API de CEP indisponível).");

        var cotacao = _servicoCalculoFrete.Calcular(solicitacao);
        return new ResultadoCalculoFrete(solicitacao.TipoServico, origem, destino, cotacao);
    }

    private static string NormalizarCep(string cep)
        => new string(cep.Where(char.IsDigit).ToArray());

    private static bool CepTemFormatoBasicoValido(string cep)
        => cep.Length == 8 && cep.All(char.IsDigit);
}
