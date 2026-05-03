namespace Rede.Domain.Exception
{
    public class ExcecaoDeDominio : System.Exception
    {

        public ExcecaoDeDominio(string mensagem) : base(mensagem)
        {

        }

        public static void HaErro(bool regra, string mensagem)
        {
            if (regra)
                throw new ExcecaoDeDominio(mensagem);
        }
    }
}