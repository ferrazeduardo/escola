using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.Usuario>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Usuario> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.NM_USUARIO).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DT_NASCIMENTO).IsRequired();
        builder.Property(x => x.NR_CPF).HasMaxLength(11).IsRequired();
        builder.HasIndex(x => x.NR_CPF).IsUnique(true);
        builder.Property(x => x.SEG_SENHA).HasMaxLength(50).IsRequired();
        builder.Property(x => x.DS_EMAIL).HasMaxLength(50).IsRequired();
        builder.HasIndex(x => x.DS_EMAIL).IsUnique(true);
        builder.Property(x => x.SALT).HasMaxLength(100).IsRequired();

        builder.HasMany(e => e.Unidades)
         .WithOne()
         .HasForeignKey("id_unidade")
         .OnDelete(DeleteBehavior.Cascade);

    }
}
