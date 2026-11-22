using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("Perfil");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.DS_PERFIL).HasMaxLength(100);

        // Seed: perfil com todas as permissões, para ter quem administre os outros perfis.
        builder.HasData(new { Id = AdministradorId, DS_PERFIL = "Administrador" });
    }

    public const int AdministradorId = 1;
}
