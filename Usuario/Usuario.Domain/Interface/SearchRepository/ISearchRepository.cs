using System;
using Usuario.Domain.SeedWork;

namespace Usuario.Domain.Interface.SearchRepository;

public interface ISearchRepository<T> where T : AggregationRoot
{
    Task<SearchOutput<T>> Search(SearchInput input,CancellationToken cancellationToken);
}
