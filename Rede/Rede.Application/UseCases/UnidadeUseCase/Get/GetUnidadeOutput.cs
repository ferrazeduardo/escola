using System;
using Rede.Application.UseCases.UnidadeUseCase.Common;
using Rede.Domain.Entity;

namespace Rede.Application.UseCases.UnidadeUseCase.Get;

public class GetUnidadeOutput
{
     public ModelUnidadeOutput? unidade { get; set; } = new();

    internal void FromEntity(Unidade unidade)
    {
            this.unidade.id = unidade.Id;
            this.unidade.endereco = unidade.DS_ENDERECO;
            this.unidade.numero = unidade.NR_UNIDADE;
            this.unidade.complemento = unidade.DS_COMPLMENTO;
            this.unidade.cep = unidade.NR_CEP;
            this.unidade.status = unidade.ST_UNIDADE;
    }
}
