using CalculoFrete.Aplicacao.Services;
using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Models;
using CalculoFrete.Infra.Strategy;

namespace CalculoFrete.Testes.Servicos;

public sealed class ServicoCalculoFreteTests
{
    private static ServicoCalculoFrete CriarServicoComEstrategiasPadrao()
    {
        IEstrategiaCalculoFrete[] estrategias =
        [
            new EstrategiaRetiradaNaLoja(),
            new EstrategiaFreteExpresso(),
            new EstrategiaFreteEconomico()
        ];

        return new ServicoCalculoFrete(estrategias);
    }

    [Fact]
    public void Calcular_quando_servico_for_retirada_na_loja_deve_retornar_valor_zero()
    {
        var servico = CriarServicoComEstrategiasPadrao();

        var solicitacao = new SolicitacaoFrete(
            cepOrigem: "01001000",
            cepDestino: "20040002",
            pesoEmKg: 1m,
            distanciaEmKm: 10,
            tipoServico: TipoServicoFrete.RetiradaNaLoja);

        var cotacao = servico.Calcular(solicitacao);

        Assert.Equal("Retirada na Loja", cotacao.NomeEstrategia);
        Assert.Equal(0m, cotacao.Valor);
        Assert.Equal("BRL", cotacao.Moeda);
    }

    [Fact]
    public void Calcular_quando_servico_for_expresso_deve_usar_estrategia_expresso()
    {
        var servico = CriarServicoComEstrategiasPadrao();

        var solicitacao = new SolicitacaoFrete(
            cepOrigem: "01001000",
            cepDestino: "20040002",
            pesoEmKg: 3m,
            distanciaEmKm: 80,
            tipoServico: TipoServicoFrete.Expresso);

        var cotacao = servico.Calcular(solicitacao);

        Assert.Equal("Frete Expresso", cotacao.NomeEstrategia);
        Assert.True(cotacao.Valor > 0m);
        Assert.Equal("BRL", cotacao.Moeda);
    }

    [Fact]
    public void Calcular_quando_servico_for_economico_deve_usar_estrategia_economico()
    {
        var servico = CriarServicoComEstrategiasPadrao();

        var solicitacao = new SolicitacaoFrete(
            cepOrigem: "01001000",
            cepDestino: "20040002",
            pesoEmKg: 2m,
            distanciaEmKm: 50,
            tipoServico: TipoServicoFrete.Economico);

        var cotacao = servico.Calcular(solicitacao);

        Assert.Equal("Frete Econômico", cotacao.NomeEstrategia);
        Assert.True(cotacao.Valor > 0m);
        Assert.Equal("BRL", cotacao.Moeda);
    }
}
