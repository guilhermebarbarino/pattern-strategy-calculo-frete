using CalculoFrete.Aplicacao.Interfaces;
using CalculoFrete.Dominio.Enums;
using CalculoFrete.Dominio.Models;

namespace CalculoFrete.ConsoleApp.UI;

public sealed class LeitorConsole : ILeitorConsole
{
    public int LerOpcaoMenu()
    {
        while (true)
        {
            Console.Write("Escolha uma opção: ");
            var texto = Console.ReadLine();

            if (int.TryParse(texto, out var opcao) && opcao is 0 or 1)
                return opcao;

            Console.WriteLine("Opção inválida.");
        }
    }

    public SolicitacaoFrete LerSolicitacaoFrete()
    {
        Console.WriteLine();
        var cepOrigem = LerTextoObrigatorio("CEP origem");
        var cepDestino = LerTextoObrigatorio("CEP destino");
        var pesoEmKg = LerDecimalMaiorQueZero("Peso (kg)");
        var distanciaEmKm = LerInteiroNaoNegativo("Distância (km)");
        var tipoServico = LerTipoServico();

        return new SolicitacaoFrete(cepOrigem, cepDestino, pesoEmKg, distanciaEmKm, tipoServico);
    }

    public void AguardarTecla(string mensagem)
    {
        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.ReadKey(intercept: true);
    }

    private static string LerTextoObrigatorio(string rotulo)
    {
        while (true)
        {
            Console.Write($"{rotulo}: ");
            var valor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(valor))
                return valor.Trim();

            Console.WriteLine("Campo obrigatório.");
        }
    }

    private static decimal LerDecimalMaiorQueZero(string rotulo)
    {
        while (true)
        {
            Console.Write($"{rotulo}: ");
            var texto = Console.ReadLine();

            if (decimal.TryParse(texto, out var valor) && valor > 0)
                return valor;

            Console.WriteLine("Valor inválido. Digite um número maior que zero.");
        }
    }

    private static int LerInteiroNaoNegativo(string rotulo)
    {
        while (true)
        {
            Console.Write($"{rotulo}: ");
            var texto = Console.ReadLine();

            if (int.TryParse(texto, out var valor) && valor >= 0)
                return valor;

            Console.WriteLine("Valor inválido. Digite um inteiro maior ou igual a zero.");
        }
    }

    private static TipoServicoFrete LerTipoServico()
    {
        Console.WriteLine();
        Console.WriteLine("Tipo de serviço:");
        Console.WriteLine("1) Econômico");
        Console.WriteLine("2) Expresso");
        Console.WriteLine("3) Retirada na loja");

        while (true)
        {
            Console.Write("Escolha (1-3): ");
            var texto = Console.ReadLine();

            if (int.TryParse(texto, out var opcao) && opcao is >= 1 and <= 3)
                return (TipoServicoFrete)opcao;

            Console.WriteLine("Opção inválida.");
        }
    }
}
