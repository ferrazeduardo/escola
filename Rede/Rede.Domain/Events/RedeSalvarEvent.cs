using Rede.Domain.SeedWork;

namespace Rede.Domain.Events;

public class RedeSalvarEvent : DomainEvent
{
    public RedeSalvarEvent(string descricao, Guid resourceId)
    {
        this.descricao = descricao;
        ResourceId = resourceId;
        MessageId = Guid.NewGuid();
    }

    public Guid MessageId { get; set; }
    public string descricao { get; set; }
    public Guid ResourceId { get; set; }
}