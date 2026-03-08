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

        builder.HasMany(x => x.usuarioRedes)
        .WithMany(e => e.perfis)
        .UsingEntity<PerfilUsuarioRede>(
            l => l.HasOne<UsuarioRede>( e => e.UsuarioRede).WithMany(e => e.perfilUsuarioRedes).HasForeignKey(e => e.ID_USUARIO_REDE),
            r => r.HasOne<Perfil>(e => e.Perfil).WithMany(e => e.perfilUsuarioRedes).HasForeignKey(e => e.ID_PERFIL)    
        );

    }
}
