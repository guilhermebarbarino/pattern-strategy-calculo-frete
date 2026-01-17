using CalculoFrete.Dominio.Interfaces;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Aplicacao.Services
{
    public sealed class ServicoCalculoFrete
    {
        private readonly IReadOnlyList<IEstrategiaCalculoFrete> _estrategias;

        public ServicoCalculoFrete(IEnumerable<IEstrategiaCalculoFrete> estrategias)
        {
            if (estrategias is null) throw new ArgumentNullException(nameof(estrategias));

            _estrategias = estrategias.ToList();
            if (_estrategias.Count == 0)
                throw new InvalidOperationException("Nenhuma estratégia de cálculo de frete foi registrada.");
        }

        public CotacaoFrete Calcular(SolicitacaoFrete solicitacao)
        {
            if (solicitacao is null) throw new ArgumentNullException(nameof(solicitacao));

            var estrategia = _estrategias.FirstOrDefault(e => e.Atende(solicitacao));
            if (estrategia is null)
                throw new InvalidOperationException($"Não existe estratégia para o serviço: {solicitacao.TipoServico}");

            return estrategia.Calcular(solicitacao);
        }
    }
}
