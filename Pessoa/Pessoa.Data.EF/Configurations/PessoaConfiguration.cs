using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pessoa.Data.EF.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Domain.SeedWorks.Pessoa>
{
    public void Configure(EntityTypeBuilder<Domain.SeedWorks.Pessoa> builder)
    {
        builder.HasKey(pessoa => pessoa.Id);
        builder.Property(pessoa => pessoa.NM_NOME)
            .HasMaxLength(201)
            .IsRequired();
        builder.Property(pessoa => pessoa.NR_CPF)
            .HasMaxLength(11)
            .IsRequired();
        builder.Property(pessoa => pessoa.NR_RG)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(pessoa => pessoa.DS_ENDERECO)
            .IsRequired()
            .HasMaxLength(200);
    
        builder.Property(pessoa => pessoa.NR_ENDERECO) 
            .IsRequired()
            .HasMaxLength(10);
    
        builder.Property(pessoa => pessoa.UF)
            .HasMaxLength(2)
            .IsRequired();
    
        builder.Property(pessoa => pessoa.DT_NASCIMENTO) 
            .IsRequired();
    
        builder.Property(pessoa => pessoa.DH_REGISTRO)
            .IsRequired();

        builder.Property(pessoa => pessoa.Id_MAE);

        builder.Property(pessoa => pessoa.Id_PAI);
        builder.Property(pessoa => pessoa.Id_REDE);
    }
}