using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF.Configurations;

public class RedeConfiguration : IEntityTypeConfiguration<Rede>
{
    public void Configure(EntityTypeBuilder<Rede> builder)
    {
        builder.HasKey(rede => rede.Id);
        builder.Property(pessoa => pessoa.Id).ValueGeneratedNever();

        builder.Property(rede => rede.DS_REDE)
            .HasMaxLength(100)
            .IsRequired();
    }
}