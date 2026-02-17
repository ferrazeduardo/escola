using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Rede.Data.EF;

public class RedeDbContextFactory : IDesignTimeDbContextFactory<RedeDbContext>
{
    public RedeDbContext CreateDbContext(string[] args)
    {
          var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Rede.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RedeDbContext>();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"));

            return new RedeDbContext(optionsBuilder.Options);
    }
}
