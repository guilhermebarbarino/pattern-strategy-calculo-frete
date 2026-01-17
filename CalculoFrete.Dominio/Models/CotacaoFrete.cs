namespace CalculoFrete.Dominio.Models
{
    public sealed class CotacaoFrete
    {
        public CotacaoFrete(decimal valor, string moeda, string nomeEstrategia)
        {
            if (valor < 0) throw new ArgumentOutOfRangeException(nameof(valor));
            if (string.IsNullOrWhiteSpace(moeda)) throw new ArgumentException("Moeda é obrigatória.", nameof(moeda));
            if (string.IsNullOrWhiteSpace(nomeEstrategia)) throw new ArgumentException("Nome da estratégia é obrigatório.", nameof(nomeEstrategia));

            Valor = decimal.Round(valor, 2, MidpointRounding.AwayFromZero);
            Moeda = moeda.Trim().ToUpperInvariant();
            NomeEstrategia = nomeEstrategia.Trim();
        }

        public decimal Valor { get; }
        public string Moeda { get; }
        public string NomeEstrategia { get; }
    }
}
