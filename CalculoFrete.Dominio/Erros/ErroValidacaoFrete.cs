namespace CalculoFrete.Dominio.Erros
{
    public sealed class ErroValidacaoFrete : Exception
    {
        public ErroValidacaoFrete(string mensagem) : base(mensagem) { }
    }
}
