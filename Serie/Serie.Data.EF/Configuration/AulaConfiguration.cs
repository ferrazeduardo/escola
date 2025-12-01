using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;
using Serie.Domain.Enum;

namespace Serie.Data.EF.Configuration;

public class AulaConfiguration : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DS_AULA).IsRequired().HasMaxLength(50);

        builder.Property(x => x.diaSemana).IsRequired().HasMaxLength(20)
        .HasConversion(v => v.ToString(), v => (DiaSemana)Enum.Parse(typeof(DiaSemana), v));
        
        builder.HasOne(x => x.horario)
        .WithOne(x => x.Aula)
        .HasPrincipalKey("ID_AULA");


        builder.HasOne(x => x.Serie)
        .WithMany(x => x.Aulas)
        .HasPrincipalKey("ID_SERIE");

        builder.HasOne(x => x.sala)
        .WithMany(x => x.Aulas)
        .HasPrincipalKey("ID_AULA");

        builder.HasOne(x => x.materia)
        .WithMany(x => x.Aulas)
        .HasPrincipalKey("ID_AULA");
    }
}
