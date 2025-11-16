using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
{
    public void Configure(EntityTypeBuilder<Materia> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DS_MATERIA).HasMaxLength(10).IsRequired();

        builder.Property(x => x.ST_MATERIA).HasMaxLength(1).IsRequired();

        // builder.HasMany(x => x.Rede)
        // .WithMany(x => x.Materias)
        // .UsingEntity<MateriaRede>(
        //     r => r.HasOne(pt => pt.Rede).WithMany(t => t.MateriaRedes).HasForeignKey(pt => pt.ID_REDE),
        //     l => l.HasOne(pt => pt.Materia).WithMany(t => t.MateriaRedes).HasForeignKey(pt => pt.ID_MATERIA)
        // );

        builder.HasMany(x => x.Rede)
        .WithMany(x => x.Materias)
        .UsingEntity(j => j.ToTable("MateriaRede"));
    }
}
