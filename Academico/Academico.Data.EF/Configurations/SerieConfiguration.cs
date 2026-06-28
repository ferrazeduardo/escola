using System;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.EF.Configurations;

public class SerieConfiguration : IEntityTypeConfiguration<Serie>
{
    public void Configure(EntityTypeBuilder<Serie> builder)
    {
        throw new NotImplementedException();
    }
}
