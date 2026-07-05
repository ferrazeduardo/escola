using System;
using Academico.Domain.Entity;

namespace Academico.Domain.Interface.Repository;

public interface IMateriaRepository
{
    Task Create(Materia materia, CancellationToken cancellationToken);
}
