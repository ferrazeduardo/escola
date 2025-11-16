using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class HorarioConfiguration : IEntityTypeConfiguration<Horario>
{
    public void Configure(EntityTypeBuilder<Horario> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.HoraFim).IsRequired();
        builder.Property(x => x.HoraInicio).IsRequired();

        builder.Property(x => x.LT_TURNO).HasMaxLength(10).IsRequired();

        builder.Property(x => x.ST_HORARIO).HasMaxLength(1).IsRequired();


    }
}
