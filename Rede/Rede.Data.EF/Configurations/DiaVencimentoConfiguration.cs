using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class DiaVencimentoConfiguration : IEntityTypeConfiguration<DiaVencimento>
{
    public void Configure(EntityTypeBuilder<DiaVencimento> builder)
    {
        // Define a chave primária
        builder.HasAlternateKey(x => new { x.ID_REDE, x.Dia });

        // Configuração da propriedade Dia
        builder.Property(x => x.Dia)
            .IsRequired();


        // Opcional: Definir o nome da tabela explicitamente
        builder.ToTable("DiaVencimento");
    }
}