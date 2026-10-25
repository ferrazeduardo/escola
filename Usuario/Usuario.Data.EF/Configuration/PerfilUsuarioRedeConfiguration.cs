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

        builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.ID_PERFIL);
        builder.HasOne(x => x.Usuario).WithMany(x => x.perfilUsuarioRedes).HasForeignKey(x => x.ID_USUARIO);
        builder.HasOne(x => x.Rede).WithMany().HasForeignKey(x => x.ID_REDE);
    }
}
