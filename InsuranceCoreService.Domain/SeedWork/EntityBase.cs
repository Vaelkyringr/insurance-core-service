namespace InsuranceCoreService.Domain.SeedWork;

public abstract class EntityBase
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; }

    public void AddDomainEvent(IDomainEvent newEvent)
    {
        _domainEvents.Add(newEvent);
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}