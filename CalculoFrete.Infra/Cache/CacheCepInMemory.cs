using CalculoFrete.Dominio.Modelos;
using CalculoFrete.Infra.Cache.Interfaces;
using System.Collections.Concurrent;

namespace CalculoFrete.Infra.Cache
{
    public sealed class CacheCepInMemory : ICacheCep
    {
        private sealed record ItemCache(EnderecoCep Endereco, DateTimeOffset ExpiraEm);

        private readonly ConcurrentDictionary<string, ItemCache> _itens = new();

        public bool TentarObter(string cep, out EnderecoCep? endereco)
        {
            endereco = null;

            if (!_itens.TryGetValue(cep, out var item))
                return false;

            if (DateTimeOffset.UtcNow > item.ExpiraEm)
            {
                _itens.TryRemove(cep, out _);
                return false;
            }

            endereco = item.Endereco;
            return true;
        }

        public void Salvar(string cep, EnderecoCep endereco, TimeSpan tempoDeVida)
        {
            var expiraEm = DateTimeOffset.UtcNow.Add(tempoDeVida);
            _itens[cep] = new ItemCache(endereco, expiraEm);
        }
    }
}
