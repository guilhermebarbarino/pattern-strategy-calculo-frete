using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Dominio.Modelos;

public sealed class ResultadoCalculoFrete
{
    public ResultadoCalculoFrete(
        TipoServicoFrete tipoServico,
        EnderecoCep origem,
        EnderecoCep destino,
        CotacaoFrete cotacao)
    {
        TipoServico = tipoServico;
        Origem = origem ?? throw new ArgumentNullException(nameof(origem));
        Destino = destino ?? throw new ArgumentNullException(nameof(destino));
        Cotacao = cotacao ?? throw new ArgumentNullException(nameof(cotacao));
    }

    public TipoServicoFrete TipoServico { get; }
    public EnderecoCep Origem { get; }
    public EnderecoCep Destino { get; }
    public CotacaoFrete Cotacao { get; }
}
