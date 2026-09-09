using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Domain.Entity;

namespace Rede.Data.EF.Configurations;

public class RedeUnidadeConfiguration : IEntityTypeConfiguration<RedeUnidade>
{
    public void Configure(EntityTypeBuilder<RedeUnidade> builder)
    {
        builder.HasKey(e => new {e.id_rede, e.id_unidade});
    }
}
