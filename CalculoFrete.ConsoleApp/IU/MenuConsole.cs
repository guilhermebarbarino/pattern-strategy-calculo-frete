using CalculoFrete.Aplicacao.Interfaces;
using CalculoFrete.Aplicacao.Services;
using CalculoFrete.Dominio.Erros;

namespace CalculoFrete.ConsoleApp.UI;

public sealed class MenuConsole
{
    private readonly ILeitorConsole _leitor;
    private readonly IFormatadorConsole _formatador;
    private readonly ServicoCalculoFreteComEndereco _servicoCompleto;


    public MenuConsole(
        ServicoCalculoFreteComEndereco servicoCompleto,
        ILeitorConsole leitor,
        IFormatadorConsole formatador
        )
    {
        _leitor = leitor ?? throw new ArgumentNullException(nameof(leitor));
        _formatador = formatador ?? throw new ArgumentNullException(nameof(formatador));
        _servicoCompleto = servicoCompleto ?? throw new ArgumentNullException(nameof(servicoCompleto));

    }

    public Task ExecutarAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Cálculo de Frete ===");
            Console.WriteLine("========================");
            Console.WriteLine("1) Calcular frete");
            Console.WriteLine("0) Sair");
            Console.WriteLine();

            var opcao = _leitor.LerOpcaoMenu();

            if (opcao == 0)
                return Task.CompletedTask;

            if (opcao == 1)
                CalcularFreteAsync();

            _leitor.AguardarTecla("Pressione qualquer tecla para voltar ao menu...");
        }
    }

    private async Task CalcularFreteAsync()
    {
        try
        {
            var solicitacao = _leitor.LerSolicitacaoFrete();
            var resultado = await _servicoCompleto.CalcularAsync(solicitacao, CancellationToken.None);

            Console.WriteLine();
            Console.WriteLine(_formatador.FormatarResultado(resultado));
        }
        catch (ErroValidacaoFrete ex)
        {
            Console.WriteLine();
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
