using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilPermissaoConfiguration : IEntityTypeConfiguration<PerfilPermissao>
{
    public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
    {
        builder.ToTable("PerfilPermissao");
        builder.HasKey(x => new {x.ID_PERFIL, x.ID_PERMISSAO});
        builder.Property(x => x.ID_PERFIL).IsRequired();
        builder.Property(x => x.ID_PERMISSAO).IsRequired();
    }
}
