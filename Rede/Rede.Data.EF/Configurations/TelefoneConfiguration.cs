using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        builder.Property(x => x.ID_REDE)
            .IsRequired();
            
        builder.Property(x => x.NR_TELEFONE)
            .HasMaxLength(60)
            .IsRequired();
    }
}