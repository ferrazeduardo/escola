using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.SearchRepository;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Interface.Repository;

public interface IPessoaRepository : ISearchRepository<Pessoa>, IRepository<Pessoa>
{
    Task<int> Count(Expression<Func<Pessoa, bool>> filtro);
}
