using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.ToTable("Unidade");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DS_UNIDADE);

        builder.HasOne(x => x.Rede)
        .WithMany(x => x.Unidades)
        .HasForeignKey("ID_REDE")
        .HasConstraintName("FK_REDE_UNIDADE");

        builder.HasMany(x => x.Perfis)
        .WithMany(x => x.Unidades)
        .UsingEntity<PerfilUnidade>(
            r => r.HasOne(pt => pt.Perfil).WithMany(t => t.PerfilUnidades).HasForeignKey(pt => pt.ID_PERFIL),
            l => l.HasOne(pt => pt.Unidade).WithMany(p => p.PerfilUnidades).HasForeignKey(pt => pt.ID_UNIDADE)
        );
    }
}
