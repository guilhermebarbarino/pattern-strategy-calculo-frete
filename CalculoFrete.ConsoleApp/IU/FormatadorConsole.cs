using CalculoFrete.Aplicacao.Interfaces;
using CalculoFrete.Dominio.Modelos;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.ConsoleApp.UI;

public sealed class FormatadorConsole : IFormatadorConsole
{
    public string FormatarCotacao(CotacaoFrete cotacao)
    {
        return $"Estratégia aplicada: {cotacao.NomeEstrategia}{Environment.NewLine}" +
               $"Valor do frete: {cotacao.Valor} {cotacao.Moeda}";
    }

    public string FormatarResultado(ResultadoCalculoFrete resultado)
    {
        var origem = FormatarEndereco("Origem", resultado.Origem);
        var destino = FormatarEndereco("Destino", resultado.Destino);

        return
            $"{origem}{Environment.NewLine}" +
            $"{destino}{Environment.NewLine}{Environment.NewLine}" +
            $"Tipo de frete: {resultado.TipoServico}{Environment.NewLine}" +
            $"Estratégia aplicada: {resultado.Cotacao.NomeEstrategia}{Environment.NewLine}" +
            $"Valor do frete: {resultado.Cotacao.Valor} {resultado.Cotacao.Moeda}";
    }

    private static string FormatarEndereco(string titulo, EnderecoCep endereco)
    {
        var logradouro = string.IsNullOrWhiteSpace(endereco.Logradouro) ? "" : $"{endereco.Logradouro}, ";
        var bairro = string.IsNullOrWhiteSpace(endereco.Bairro) ? "" : $"{endereco.Bairro}, ";

        return $"{titulo}: {endereco.Cep} — {logradouro}{bairro}{endereco.Cidade}/{endereco.Uf}";
    }
}
