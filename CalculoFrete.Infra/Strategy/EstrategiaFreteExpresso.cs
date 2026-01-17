using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Infra.Strategy
{
    public sealed class EstrategiaFreteExpresso : IEstrategiaCalculoFrete
    {
        public string Nome => "Frete Expresso";

        public bool Atende(SolicitacaoFrete solicitacao) =>
            solicitacao.TipoServico == TipoServicoFrete.Expresso;

        public CotacaoFrete Calcular(SolicitacaoFrete solicitacao)
        {
            const decimal taxaBase = 18m;
            const decimal taxaUrgencia = 8m;
            const decimal taxaPorKm = 0.12m;
            const decimal taxaPorKg = 1.60m;

            var valor = taxaBase + taxaUrgencia
                      + (solicitacao.DistanciaEmKm * taxaPorKm)
                      + (solicitacao.PesoEmKg * taxaPorKg);

            return new CotacaoFrete(valor, "BRL", Nome);
        }
    }
}
