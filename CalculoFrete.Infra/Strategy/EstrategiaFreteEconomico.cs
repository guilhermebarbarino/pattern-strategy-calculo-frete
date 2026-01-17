using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Infra.Strategy
{
    public sealed class EstrategiaFreteEconomico : IEstrategiaCalculoFrete
    {
        public string Nome => "Frete Econômico";

        public bool Atende(SolicitacaoFrete solicitacao) =>
            solicitacao.TipoServico == TipoServicoFrete.Economico;

        public CotacaoFrete Calcular(SolicitacaoFrete solicitacao)
        {
            const decimal taxaBase = 10m;
            const decimal taxaPorKm = 0.08m;
            const decimal taxaPorKg = 1.20m;

            var valor = taxaBase
                      + (solicitacao.DistanciaEmKm * taxaPorKm)
                      + (solicitacao.PesoEmKg * taxaPorKg);

            return new CotacaoFrete(valor, "BRL", Nome);
        }
    }
}