using System;
using Usuario.Domain.SeedWork;
using domain = Usuario.Domain.Entity;

namespace Usuario.Domain.Interface.Repository;

public interface IUsuarioRepository : IRepository<domain.Usuario>
{
}
