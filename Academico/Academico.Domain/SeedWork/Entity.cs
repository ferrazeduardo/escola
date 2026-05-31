using System;

namespace Academico.Domain.SeedWork;

public abstract class Entity
{
    public int Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (Entity)obj;

        return Id == entity.Id;
    }
}
