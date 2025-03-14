using Microsoft.EntityFrameworkCore;

namespace Pessoa.Data.EF;

public class PessoaDbContext  : DbContext
{
    public DbSet<Domain.SeedWorks.Pessoa> Pessoas => Set<Domain.SeedWorks.Pessoa>();

    public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
    {
        
    }
}