using System;
using Academico.Domain.Entity;
using Academico.Domain.Interface.SearchRepository;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Interface.Repository;

public interface IMateriaRepository : IRepository<Materia>, ISearchRepository<Materia>
{
    Task<List<Materia>?> ListByIds(ICollection<int> materiasId);
}
