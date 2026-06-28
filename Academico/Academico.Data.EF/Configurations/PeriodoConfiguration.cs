using System;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.EF.Configurations;

public class PeriodoConfiguration : IEntityTypeConfiguration<Periodo>
{
    public void Configure(EntityTypeBuilder<Periodo> builder)
    {
        throw new NotImplementedException();
    }
}
