using CalculoFrete.Dominio.Modelos;

namespace CalculoFrete.Dominio.Interfaces
{
    public interface IConsultaCep
    {
        Task<EnderecoCep?> ConsultarAsync(string cep, CancellationToken cancellationToken);
    }
}
