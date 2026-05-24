using System;
using Academico.Domain.Exception;

namespace Academico.Domain.Validator;

public class ValidadorDeRegra
{
    private string Mensagens { get; set; } = "";

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
        if (string.IsNullOrEmpty(Mensagens) is false)
            throw new ExcecaoDeDominio(Mensagens);
    }
}
