using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rede.Domain.SeedWork;

public abstract class Entity
{
    
    [BsonGuidRepresentation(GuidRepresentation.Standard)] public Guid Id { get; protected set; }
    
    protected Entity() =>
        Id = Guid.NewGuid();
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var entity = (Entity)obj;
        return Id == entity.Id;
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
