using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class RedeConfiguration : IEntityTypeConfiguration<Domain.Entity.Rede>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Rede> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.RZ_SOCIAL)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(x => x.NR_CNPJ)
            .HasMaxLength(14)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(x => x.ST_REDE)
            .HasMaxLength(1)
            .IsRequired();

        builder.Property(x => x.US_REGISTRO)
            .IsRequired();

        builder.Property(x => x.DH_REGISTRO)
            .IsRequired();


    }
}