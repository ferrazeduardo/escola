using System;
using Usuario.Domain.Exception;

namespace Usuario.Domain.Validation;

public class ValidadorDeRegra
{
    private string Mensagens = "";
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
            Mensagens = mensagem;

        return this;
    }

    public void DispararExcecaoSeExistir()
    {
        if(string.IsNullOrEmpty(Mensagens) is false)
           throw new ExcecaoDeDominio(Mensagens);
    }
}
