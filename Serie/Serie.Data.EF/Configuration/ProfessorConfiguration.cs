using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NM_PROFESSOR).HasMaxLength(60).IsRequired();

        builder.HasMany(x => x.Materias)
               .WithMany(x => x.Professor)
               .UsingEntity<Dictionary<String, object>>(
                "ProfessorMateria",
                j => j.HasOne<Materia>().WithMany().HasForeignKey("ID_MATERIA"),
                l => l.HasOne<Professor>().WithMany().HasForeignKey("ID_PROFESSOR")
               );
    }
}
