using System;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Interface.SearchRepository;

public interface ISearchRepository<T> where T : AggregateRoot
{
    Task<SearchOutput<T>> Search(SearchInput input);
}
