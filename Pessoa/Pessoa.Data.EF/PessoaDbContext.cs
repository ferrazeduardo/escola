using Microsoft.EntityFrameworkCore;
using Pessoa.Data.EF.Configurations;
using Pessoa.Domain.Entity;

namespace Pessoa.Data.EF;

public class PessoaDbContext  : DbContext
{
    public DbSet<Domain.SeedWorks.Pessoa> Pessoas => Set<Domain.SeedWorks.Pessoa>();
    public DbSet<Telefone> Telefone => Set<Telefone>();
    public DbSet<Rede> Rede => Set<Rede>();

    public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaConfiguration());
        modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        modelBuilder.ApplyConfiguration(new RedeConfiguration());
        //base.OnModelCreating(modelBuilder);
    }
}