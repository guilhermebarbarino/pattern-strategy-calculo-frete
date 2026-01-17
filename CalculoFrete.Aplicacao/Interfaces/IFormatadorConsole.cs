using CalculoFrete.Dominio.Modelos;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Aplicacao.Interfaces
{
    public interface IFormatadorConsole
    {
        string FormatarCotacao(CotacaoFrete cotacao);
        string FormatarResultado(ResultadoCalculoFrete resultado);
    }
}
