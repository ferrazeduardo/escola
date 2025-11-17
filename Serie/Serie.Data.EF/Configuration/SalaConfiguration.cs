using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class SalaConfiguration : IEntityTypeConfiguration<Sala>
{
    public void Configure(EntityTypeBuilder<Sala> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NR_SALA).HasMaxLength(10).IsRequired();

        builder.HasOne(x => x.Unidade)
        .WithMany(x => x.Salas)
        .HasPrincipalKey("ID_UNIDADE");
    }
}
