namespace Rede.Domain.SeedWork;

public abstract class DomainEvent
{
    public DateTime DT_EVENT { get; set; }

    public DomainEvent()
    {
        DT_EVENT = DateTime.Now;
    }
}