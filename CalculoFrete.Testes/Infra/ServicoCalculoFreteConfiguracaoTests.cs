using CalculoFrete.Aplicacao.Services;
using CalculoFrete.Dominio.Interfaces;

namespace CalculoFrete.Testes.Infra;

public sealed class ServicoCalculoFreteConfiguracaoTests
{
    [Fact]
    public void Construtor_quando_nao_ha_estrategias_registradas_deve_lancar_excecao()
    {
        IEstrategiaCalculoFrete[] estrategias = [];
        Assert.Throws<InvalidOperationException>(() => new ServicoCalculoFrete(estrategias));
    }
}
