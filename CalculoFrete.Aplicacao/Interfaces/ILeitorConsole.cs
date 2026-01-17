using CalculoFrete.Dominio.Models;

namespace CalculoFrete.Aplicacao.Interfaces
{
    public interface ILeitorConsole
    {
        int LerOpcaoMenu();
        SolicitacaoFrete LerSolicitacaoFrete();
        void AguardarTecla(string mensagem);
    }
}
