using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DS_ENDERECO)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.NR_UNIDADE)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.NR_CEP)
            .HasMaxLength(8)
            .IsRequired();
        
        builder.Property(x => x.ST_UNIDADE)
            .HasMaxLength(1)
            .IsRequired();

        builder.Property(x => x.DH_REGISTRO)
            .IsRequired();

        builder.Property(x => x.US_REGISTRO)
            .IsRequired();
        
        builder.Property(x => x.DS_COMPLMENTO)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x =>x.ID_REDE)
            .IsRequired();

    }
}