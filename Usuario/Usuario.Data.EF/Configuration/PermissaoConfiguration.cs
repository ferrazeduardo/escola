using System;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Permissao> builder)
    {
        builder.ToTable("Permisao");
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.PL_PERMISSAO).HasMaxLength(50).IsRequired();
        builder.Property(x => x.DS_PERMISSAO).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DS_MODULO).HasMaxLength(50).IsRequired();
    }
}
