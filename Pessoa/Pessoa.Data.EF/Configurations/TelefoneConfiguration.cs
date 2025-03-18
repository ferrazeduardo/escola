using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF.Configurations;

public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        builder.HasNoKey();

        builder.Property(telefone => telefone.Id)
            .ValueGeneratedNever();

        builder.Property(telefone => telefone.NR_TELEFONE)
            .HasMaxLength(20) 
            .IsRequired(); 
    }
}