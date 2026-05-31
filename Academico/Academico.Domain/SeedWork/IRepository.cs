using System;
using System.Linq.Expressions;
using Academico.Domain.Entity;
using Academico.Domain.Interface.SearchRepository;

namespace Academico.Domain.SeedWork;

public interface IRepository<T>
{
    Task Cadastrar(T entity, CancellationToken cancellationToken);
    Task<T> Get(Expression<Func<T, bool>> filtro, bool rastrear = true);
    Task<SearchOutput<Pessoa>> Search(SearchInput input);
    Task Update(T entity, CancellationToken cancellationToken);

    Task<List<T>> List(Expression<Func<List<T>, bool>> filtro, bool rastrear = true);
    Task Delete(T entity, CancellationToken cancellationToken);
}
