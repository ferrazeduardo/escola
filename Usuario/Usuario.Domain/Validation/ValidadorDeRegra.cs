using System;
using Usuario.Domain.Exception;

namespace Usuario.Domain.Validation;

public class ValidadorDeRegra
{
    private List<string> Mensagens = new List<string>();
    public ValidadorDeRegra()
    {
    }

    public static ValidadorDeRegra Novo()
    {
        return new ValidadorDeRegra();
    }

    public ValidadorDeRegra Quando(bool temErro, string mensagem)
    {
        if (temErro)
            Mensagens.Add(mensagem);

        return this;
    }

    public void DispararExcecaoSeExistir()
    {
        if(Mensagens.Count > 0)
           throw new ExcecaoDeDominio(string.Join(", ", Mensagens));
    }
}
