using System;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.EF.Configurations;

public class PeriodoConfiguration : IEntityTypeConfiguration<Periodo>
{
    public void Configure(EntityTypeBuilder<Periodo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NR_ANO).IsRequired();
        builder.Property(x => x.ST_PERIODO).IsRequired();
        builder.Property(x => x.DT_INICIO).IsRequired();
        builder.Property(x => x.DT_FIM).IsRequired();
    }
}
