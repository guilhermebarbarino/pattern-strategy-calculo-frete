namespace CalculoFrete.Dominio.Modelos;

public sealed class EnderecoCep
{
    public EnderecoCep(string cep, string cidade, string uf, string? logradouro, string? bairro)
    {
        if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("CEP é obrigatório.", nameof(cep));
        if (string.IsNullOrWhiteSpace(cidade)) throw new ArgumentException("Cidade é obrigatória.", nameof(cidade));
        if (string.IsNullOrWhiteSpace(uf)) throw new ArgumentException("UF é obrigatória.", nameof(uf));

        Cep = cep.Trim();
        Cidade = cidade.Trim();
        Uf = uf.Trim().ToUpperInvariant();
        Logradouro = string.IsNullOrWhiteSpace(logradouro) ? null : logradouro.Trim();
        Bairro = string.IsNullOrWhiteSpace(bairro) ? null : bairro.Trim();
    }

    public string Cep { get; }
    public string Cidade { get; }
    public string Uf { get; }
    public string? Logradouro { get; }
    public string? Bairro { get; }
}
