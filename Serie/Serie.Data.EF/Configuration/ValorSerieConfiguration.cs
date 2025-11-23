using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class ValorSerieConfiguration : IEntityTypeConfiguration<ValorSerie>
{
    public void Configure(EntityTypeBuilder<ValorSerie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.VL_Serie).IsRequired();

        builder.Property(x => x.DS_TURNO).IsRequired().HasMaxLength(10);

        builder.HasOne(x => x.Serie)
        .WithMany(x => x.ValorSeries)
        .HasPrincipalKey("ID_SERIE");
    }
}
