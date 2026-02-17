using Microsoft.EntityFrameworkCore;
using Rede.Data.EF.Configurations;
using Rede.Domain.Entity;

namespace Rede.Data.EF;

public class RedeDbContext  : DbContext
{
    public DbSet<Domain.Entity.Rede> Rede => Set<Domain.Entity.Rede>();
    public DbSet<Telefone> Telefone => Set<Telefone>();
    public DbSet<Unidade> Unidade => Set<Unidade>();
    public DbSet<DiaVencimento> DiaVencimento => Set<DiaVencimento>();
    
    
    public RedeDbContext(DbContextOptions<RedeDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RedeConfiguration());
        modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        modelBuilder.ApplyConfiguration(new UnidadeConfiguration());
        modelBuilder.ApplyConfiguration(new DiaVencimentoConfiguration());
    }
}