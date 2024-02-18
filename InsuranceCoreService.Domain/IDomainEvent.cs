namespace InsuranceCoreService.Domain;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
