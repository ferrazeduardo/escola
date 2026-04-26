using System;
using Microsoft.EntityFrameworkCore;
using Usuario.Data.EF.Configuration;

namespace Usuario.Data.EF;

public class UsuarioDbContext : DbContext
{

    public DbSet<Usuario.Domain.Entity.Usuario> usuarios => Set<Usuario.Domain.Entity.Usuario>();
    public DbSet<Usuario.Domain.Entity.Perfil> perfis => Set<Usuario.Domain.Entity.Perfil>();
    public DbSet<Usuario.Domain.Entity.PerfilUsuarioRede> perfilUsuarioRedes => Set<Usuario.Domain.Entity.PerfilUsuarioRede>();

    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilUsuarioRedeConfiguration());
    }
}
