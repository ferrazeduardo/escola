using System;
using Microsoft.EntityFrameworkCore;
using Serie.Data.EF.Configuration;
using Serie.Domain.Entity;

namespace Serie.Data.EF;

public class SerieDbContext : DbContext
{
    public DbSet<Materia> materias => Set<Materia>();
    public DbSet<Serie.Domain.Entity.Serie> series => Set<Serie.Domain.Entity.Serie>();
    public DbSet<Aula> aulas => Set<Aula>();
    public DbSet<Horario> horarios => Set<Horario>();
    public DbSet<Professor> professors => Set<Professor>();
    public DbSet<Rede> redes => Set<Rede>();
    public DbSet<Sala> salas => Set<Sala>();
    public DbSet<Unidade> unidades => Set<Unidade>();

    public SerieDbContext(DbContextOptions<SerieDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MateriaConfiguration());
        modelBuilder.ApplyConfiguration(new HorarioConfiguration());
        modelBuilder.ApplyConfiguration(new SalaConfiguration());
        modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
    }
}
