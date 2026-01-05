using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Usuario.Data.EF;

public class UsuarioDbContextFactory : IDesignTimeDbContextFactory<UsuarioDbContext>
{
    public UsuarioDbContext CreateDbContext(string[] args)
    {
         var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Usuario.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<UsuarioDbContext>();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"));

            return new UsuarioDbContext(optionsBuilder.Options);
    }
}
