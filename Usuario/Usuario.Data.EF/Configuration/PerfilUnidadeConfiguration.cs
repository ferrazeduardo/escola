using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilUnidadeConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.PerfilUnidade>
{
    public void Configure(EntityTypeBuilder<PerfilUnidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ID_PERFIL).IsRequired().HasColumnName("ID_PERFIL");
        builder.Property(e => e.ID_UNIDADE).IsRequired().HasColumnName("ID_UNIDADE");
    }
}
