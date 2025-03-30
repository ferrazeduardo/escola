using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pessoa.Data.EF.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Domain.SeedWorks.Pessoa>
{
    public void Configure(EntityTypeBuilder<Domain.SeedWorks.Pessoa> builder)
    {
        builder.HasKey(pessoa => pessoa.Id);
        builder.Property(pessoa => pessoa.Id).ValueGeneratedOnAdd();
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
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.HasOne(pessoa => pessoa.Mae)
            .WithMany(pessoa => pessoa.FilhosComoMae)
            .HasForeignKey(pessoa => pessoa.Id_MAE)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pessoa => pessoa.Pai)
            .WithMany(pessoa => pessoa.FilhosComoPai)
            .HasForeignKey(pessoa => pessoa.Id_PAI)
            .OnDelete(DeleteBehavior.Restrict); 
        
        builder.Property(pessoa => pessoa.Id_MAE).ValueGeneratedOnAdd();

        builder.Property(pessoa => pessoa.Id_PAI).ValueGeneratedOnAdd();
        
        builder.HasOne(pessoa => pessoa.Rede)
            .WithOne()
            .HasForeignKey<Domain.SeedWorks.Pessoa>(pessoa => pessoa.ID_REDE)
            .OnDelete(DeleteBehavior.Restrict); 
        //    .HasForeignKey<Domain.SeedWorks.Pessoa>("ID_REDE");

        builder.HasMany(pessoa => pessoa.Telefones)
            .WithOne(telefone => telefone.Pessoa)
            .HasForeignKey(telefone => telefone.ID_PESSOA)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasIndex(pessoa => new { pessoa.NR_CPF, pessoa.ID_REDE })
            .IsUnique();

    }
}