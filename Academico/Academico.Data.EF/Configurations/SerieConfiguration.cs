using System;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.EF.Configurations;

public class SerieConfiguration : IEntityTypeConfiguration<Serie>
{
    public void Configure(EntityTypeBuilder<Serie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NR_SERIE).IsRequired();
        builder.Property(x => x.ST_SERIE).IsRequired();

        builder.Ignore(x => x.periodosId);
        builder.Ignore(x => x.unidadeId);
        builder.Ignore(x => x.nrSala);

        builder.Ignore(x => x.redeId);
        builder.Ignore(x => x.materiasId);
    }
}
