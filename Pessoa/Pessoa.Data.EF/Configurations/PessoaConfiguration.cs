using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pessoa.Data.EF.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Domain.SeedWorks.Pessoa>
{
    public void Configure(EntityTypeBuilder<Domain.SeedWorks.Pessoa> builder)
    {
        builder.HasKey(pessoa => pessoa.Id);
        builder.Property(pessoa => pessoa.NM_NOME)
            .HasMaxLength(201);
    }
}