using CalculoFrete.Dominio.Modelos;

namespace CalculoFrete.Infra.Cache.Interfaces
{
    public interface ICacheCep
    {
        bool TentarObter(string cep, out EnderecoCep? endereco);
        void Salvar(string cep, EnderecoCep endereco, TimeSpan tempoDeVida);
    }
}
