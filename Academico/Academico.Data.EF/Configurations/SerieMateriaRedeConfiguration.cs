using System;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.EF.Configurations;

public class SerieMateriaRedeConfiguration : IEntityTypeConfiguration<SerieMateriaRede>
{
    public void Configure(EntityTypeBuilder<SerieMateriaRede> builder)
    {
        builder.HasKey(x => new { x.ID_SERIE, x.ID_MATERIA, x.ID_REDE });
    }
}
