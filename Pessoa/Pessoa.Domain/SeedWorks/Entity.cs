using Pessoa.Domain.Entity;

namespace Pessoa.Domain.SeedWorks;

public abstract class Entity
{
    public Guid Id { get; set; }
    
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