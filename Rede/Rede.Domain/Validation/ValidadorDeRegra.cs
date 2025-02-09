using Rede.Domain.Exception;

namespace Rede.Domain.Validation;

public class ValidadorDeRegra
{
    private readonly List<string> _mensagens;

    public ValidadorDeRegra()
    {
        _mensagens = new List<string>();
    }

    public static ValidadorDeRegra Novo()
    {
        return new ValidadorDeRegra();
    }

    public void Quando(bool temErro, string mensagem)
    {
        if (temErro)
            _mensagens.Add(mensagem);
    }


    public void DispararExcecaoSeExistir()
    {
        if(_mensagens.Any())
            throw new ExcecaoDeDominio(_mensagens);
    }
}