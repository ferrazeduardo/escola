using System;
using Academico.Data.EF.Configurations;
using Academico.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data.EF;

public class AcademicoDbContext : DbContext
{
    public DbSet<Pessoa> Pessoa => Set<Pessoa>();
    public AcademicoDbContext(DbContextOptions<AcademicoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaConfiguration());
    }
}
