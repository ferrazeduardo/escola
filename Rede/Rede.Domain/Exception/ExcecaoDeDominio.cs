namespace Rede.Domain.Exception
{
    public class ExcecaoDeDominio : System.Exception
    {
        public IEnumerable<string> Mensagens { get; }

        public ExcecaoDeDominio(string mensagem) : base(mensagem)
        {
            
        }
    }
}