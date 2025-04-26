using Rede.Domain.SeedWork;

namespace Rede.Domain.Events;

public class RedeSalvarEvent : DomainEvent
{
    public RedeSalvarEvent(string razaoSocial, Guid resourceId)
    {
        this.razaoSocial = razaoSocial;
        ResourceId = resourceId;
        MessageId = Guid.NewGuid();
    }

    public Guid MessageId { get; set; }
    public string razaoSocial { get; set; }
    public Guid ResourceId { get; set; }
}