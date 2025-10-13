using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PerfilConfiguration : IEntityTypeConfiguration<Usuario.Domain.Entity.Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.DS_PERFIL).HasMaxLength(100);
   
    }
}
