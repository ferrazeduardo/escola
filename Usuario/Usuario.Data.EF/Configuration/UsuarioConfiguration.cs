using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usuario.Data.EF.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.Usuario>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Usuario> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.NM_USUARIO).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DT_NASCIMENTO).IsRequired();
        builder.Property(x => x.NR_CPF).IsRequired().IsUnicode();

        builder.Property(x => x.SEG_SENHA).IsRequired();
        builder.Property(x => x.SALT).IsRequired();
        
    }
}
