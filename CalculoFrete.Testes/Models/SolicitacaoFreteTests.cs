using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Testes;

public sealed class SolicitacaoFreteTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Construtor_quando_cep_origem_for_invalido_deve_lancar_excecao(string? cepOrigem)
    {
        Assert.Throws<ArgumentException>(() =>
            new SolicitacaoFrete(cepOrigem!, "20040002", 1m, 10, TipoServicoFrete.Economico));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Construtor_quando_peso_for_menor_ou_igual_a_zero_deve_lancar_excecao(decimal peso)
    {
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>
            new SolicitacaoFrete("01001000", "20040002", peso, 10, TipoServicoFrete.Economico));
    }

    [Fact]
    public void Construtor_quando_distancia_for_negativa_deve_lancar_excecao()
    {
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>
            new SolicitacaoFrete("01001000", "20040002", 1m, -1, TipoServicoFrete.Economico));
    }
}
