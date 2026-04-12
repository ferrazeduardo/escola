using System;
using Usuario.Application.UseCases.Common;
using Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.PerfilUseCase.List;

public class ListPerfilOutput
{
    public List<PerfilModalOutput> perfis { get; set; }

    public void From(List<Perfil> perfis)
    {
        this.perfis = perfis.Select(p => new PerfilModalOutput
        {
            id = p.Id,
            descricao = p.DS_PERFIL
        }).ToList();
    }
}
