using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serie.Domain.Entity;

namespace Serie.Data.EF.Configuration;

public class SerieConfiguration : IEntityTypeConfiguration<Domain.Entity.Serie>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Serie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.AA_MATRICULA).IsRequired();
        builder.Property(x => x.DT_FIM).IsRequired();
        builder.Property(x => x.DT_INICIO).IsRequired();

        builder.Property(x => x.QT_AVALIACAO).IsRequired();
        builder.Property(x => x.VL_MEDIA).IsRequired();

        builder.HasOne(x => x.Rede)
        .WithOne(x => x.Serie)
        .HasPrincipalKey("ID_REDE");

        builder.HasMany(s => s.Salas)
     .WithMany(s => s.Series)
     .UsingEntity<Dictionary<string, object>>(
         "SerieSala",
         l => l.HasOne<Sala>()
               .WithMany()
               .HasForeignKey("ID_SALA"),
         r => r.HasOne<Domain.Entity.Serie>()
               .WithMany()
               .HasForeignKey("ID_SERIE"));




    }
}
