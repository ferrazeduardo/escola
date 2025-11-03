using System;
using Serie.Domain.Exceptions;

namespace Serie.Domain.Validator;

public class ValidadorDeRegra
{
    private String mensagem;

    public ValidadorDeRegra()
    {
        mensagem = "";
    }

    public static ValidadorDeRegra Novo()
    {
        return new ValidadorDeRegra();
    }

    public ValidadorDeRegra Quando(bool erro, String mensagem)
    {
        if (erro)
            this.mensagem = mensagem;

        return this;
    }

    public void DispararQuandoExistirErro()
    {
        if (this.mensagem != "")
            throw new ExcecaoDeDominio(this.mensagem);
    }
}
