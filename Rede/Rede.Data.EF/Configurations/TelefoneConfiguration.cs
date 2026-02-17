using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasKey(x => x.Id);


        builder.Property(x => x.NR_TELEFONE)
            .HasMaxLength(60)
            .IsRequired();

        builder.HasOne(x => x.Unidade)
        .WithMany(x => x.Telefones)
        .HasConstraintName("ID_UNIDADE")
        .OnDelete(DeleteBehavior.Cascade);

    }
}