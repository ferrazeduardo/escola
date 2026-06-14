using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Academico.Data.EF;

public class AcademicoDbContextFactory : IDesignTimeDbContextFactory<AcademicoDbContext>
{
    public AcademicoDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Academico.Api"))
        .AddJsonFile("appsettings.json")
        .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AcademicoDbContext>();
        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection")
        );

        return new AcademicoDbContext(optionsBuilder.Options);
    }
}
