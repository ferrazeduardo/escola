using System;
using Usuario.Application.UseCases.Common;
using Usuario.Domain.Entity;

namespace Usuario.Application.UseCases.PerfilUseCase.Get;

public class GetPerfilOutput
{
    public PerfilModalOutput perfil { get; set; } = new();
    internal void From(Perfil perfil)
    {
       this.perfil.id = perfil.Id;
       this.perfil.descricao = perfil.DS_PERFIL;
    }
}
