using System;

namespace Academico.Domain.Entity;

public class Historico : SeedWork.Entity
{
    public int alunoId {get; private set;} 
    public int turmaId {get; private set;} 
    public List<int> notasId {get; private set;} = [];
    public List<int> frequenciasId {get; private set;} = [];

}
