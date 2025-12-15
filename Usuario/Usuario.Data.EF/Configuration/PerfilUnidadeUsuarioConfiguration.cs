using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilUnidadeUsuarioConfuguration : IEntityTypeConfiguration<PerfilUnidadeUsuario>
{
    public void Configure(EntityTypeBuilder<PerfilUnidadeUsuario> builder)
    {
        builder.Property(e => e.ID_PERFIL_UNIDADE).IsRequired().HasColumnName("ID_PERFIL_UNIDADE");
        builder.Property(e => e.ID_USUARIO).IsRequired().HasColumnName("ID_USUARIO");
    }
}
