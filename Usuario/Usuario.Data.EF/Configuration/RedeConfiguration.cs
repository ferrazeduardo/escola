using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class RedeConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.Rede>
{
    public void Configure(EntityTypeBuilder<Rede> builder)
    {
        builder.ToTable("Rede");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.DS_REDE).IsRequired().HasMaxLength(100);
    }
}
