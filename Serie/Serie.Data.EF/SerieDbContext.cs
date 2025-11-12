using System;
using Microsoft.EntityFrameworkCore;
using Serie.Domain.Entity;

namespace Serie.Data.EF;

public class SerieDbContext : DbContext
{
    public DbSet<Materia> materias => Set<Materia>();
}
