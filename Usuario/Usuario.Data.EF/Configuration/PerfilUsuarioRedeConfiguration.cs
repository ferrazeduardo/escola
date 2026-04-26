using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilUsuarioRedeConfiguration : IEntityTypeConfiguration<PerfilUsuarioRede>
{
    public void Configure(EntityTypeBuilder<PerfilUsuarioRede> builder)
    {
        builder.HasKey(x => new { x.ID_PERFIL, x.ID_REDE, x.ID_USUARIO });
    }
}
