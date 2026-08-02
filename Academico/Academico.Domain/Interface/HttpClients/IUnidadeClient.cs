using System;
using Academico.Domain.Entity;

namespace Academico.Domain.Interface.HttpClients;

public interface IUnidadeClient
{
    Task<Unidade> Obter(int unidadeId);
}
