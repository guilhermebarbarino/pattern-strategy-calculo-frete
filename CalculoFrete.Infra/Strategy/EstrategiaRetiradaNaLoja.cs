using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Infra.Strategy
{
    public sealed class EstrategiaRetiradaNaLoja : IEstrategiaCalculoFrete
    {
        public string Nome => "Retirada na Loja";

        public bool Atende(SolicitacaoFrete solicitacao) =>
            solicitacao.TipoServico == TipoServicoFrete.RetiradaNaLoja;

        public CotacaoFrete Calcular(SolicitacaoFrete solicitacao) =>
            new CotacaoFrete(0m, "BRL", Nome);
    }
}
