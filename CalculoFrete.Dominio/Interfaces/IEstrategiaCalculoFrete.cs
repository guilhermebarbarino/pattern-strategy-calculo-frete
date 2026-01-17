using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Dominio.Interfaces
{
    public interface IEstrategiaCalculoFrete
    {
        string Nome { get; }

        bool Atende(SolicitacaoFrete solicitacao);

        CotacaoFrete Calcular(SolicitacaoFrete solicitacao);
    }
}
