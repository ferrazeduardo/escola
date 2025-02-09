namespace Rede.Domain.Exception
{
    public class ExcecaoDeDominio : System.Exception
    {
        public IEnumerable<string> Mensagens { get; }

        public ExcecaoDeDominio(
            IEnumerable<string> mensagens
        ) : base(string.Join(" \n - ", mensagens))
        {
            Mensagens = mensagens;
        }
    }
}