using System;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.SearchRepository;
using Usuario.Domain.SeedWork;
using domain = Usuario.Domain.Entity;

namespace Usuario.Domain.Interface.Repository;

public interface IUsuarioRepository : IRepository<domain.Usuario>, ISearchRepository<domain.Usuario>
{
}
