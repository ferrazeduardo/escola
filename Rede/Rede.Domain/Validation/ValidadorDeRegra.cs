using System;
using Rede.Domain.Exception;

namespace Rede.Domain.Validation;

public class ValidadorDeRegra
{

    public ValidadorDeRegra()
    {
    }

    public ValidadorDeRegra Novo()
    {
        return new ValidadorDeRegra();
    }

    public void Quando(bool regra, string mensagem)
    {
        if (regra)
            throw new ExcecaoDeDominio(mensagem);
    }

}
