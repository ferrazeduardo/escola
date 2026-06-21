using System;
using Academico.Domain.Entity;
using Academico.Domain.SeedWork;

namespace Academico.Domain.Interface.Repository;

public interface IPeriodoRepository : IRepository<Periodo>
{
    Task<List<Domain.Entity.Periodo>> ListAll(DateTime anoInicio,DateTime anoFIm);

}
