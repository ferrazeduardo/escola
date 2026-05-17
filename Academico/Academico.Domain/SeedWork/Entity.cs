using System;

namespace Academico.Domain.SeedWork;

public abstract class Entity
{
    public int Id { get; protected set; }
    public Guid IdGuid { get; protected set; }
    protected Entity()
    {
        IdGuid = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (Entity)obj;

        return Id == entity.Id && IdGuid == entity.IdGuid;
    }
}
