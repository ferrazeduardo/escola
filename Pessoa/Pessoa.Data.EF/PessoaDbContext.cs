using Microsoft.EntityFrameworkCore;
using Pessoa.Data.EF.Configurations;

namespace Pessoa.Data.EF;

public class PessoaDbContext  : DbContext
{
    public DbSet<Domain.SeedWorks.Pessoa> Pessoas => Set<Domain.SeedWorks.Pessoa>();

    public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaConfiguration());
        //base.OnModelCreating(modelBuilder);
    }
}