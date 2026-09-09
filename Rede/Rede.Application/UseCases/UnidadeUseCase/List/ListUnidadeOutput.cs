using System;
using Rede.Application.UseCases.UnidadeUseCase.Common;
using Rede.Domain.Entity;

namespace Rede.Application.UseCases.UnidadeUseCase.List;

public class ListUnidadeOutput
{
    public List<ModelUnidadeOutput> unidades { get; set; }

    internal void FromEntity(List<Unidade> unidades)
    {
        this.unidades = unidades.Select(x => new ModelUnidadeOutput
        {
            id = x.Id,
            endereco = x.DS_ENDERECO,
            numero = x.NR_UNIDADE,
            complemento = x.DS_COMPLMENTO,
            cep = x.NR_CEP,
            status = x.ST_UNIDADE
        }).ToList();
    }
}
