using CalculoFrete.Dominio.Enums;

namespace CalculoFrete.Dominio.Models
{
    public sealed class SolicitacaoFrete
    {
        public SolicitacaoFrete(
            string cepOrigem,
            string cepDestino,
            decimal pesoEmKg,
            int distanciaEmKm,
            TipoServicoFrete tipoServico)
        {
            if (string.IsNullOrWhiteSpace(cepOrigem))
                throw new ArgumentException("CEP de origem é obrigatório.", nameof(cepOrigem));

            if (string.IsNullOrWhiteSpace(cepDestino))
                throw new ArgumentException("CEP de destino é obrigatório.", nameof(cepDestino));

            if (pesoEmKg <= 0)
                throw new ArgumentOutOfRangeException(nameof(pesoEmKg), "Peso deve ser maior que zero.");

            if (distanciaEmKm < 0)
                throw new ArgumentOutOfRangeException(nameof(distanciaEmKm), "Distância não pode ser negativa.");

            CepOrigem = cepOrigem.Trim();
            CepDestino = cepDestino.Trim();
            PesoEmKg = pesoEmKg;
            DistanciaEmKm = distanciaEmKm;
            TipoServico = tipoServico;
        }

        public string CepOrigem { get; }
        public string CepDestino { get; }
        public decimal PesoEmKg { get; }
        public int DistanciaEmKm { get; }
        public TipoServicoFrete TipoServico { get; }
    }
}
