using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class RedeConfiguration : IEntityTypeConfiguration<Rede>
{
    public void Configure(EntityTypeBuilder<Rede> builder)
    {
        builder.HasKey(X => X.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.RZ_SOCIAL).HasMaxLength(200).IsRequired();

        builder.HasMany(x => x.Unidades)
        .WithOne(x => x.Rede)
        .HasForeignKey("ID_UNIDADE");
    }
}
