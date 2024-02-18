using InsuranceCoreService.Domain;

namespace InsuranceCoreService.Infrastructure.Services;

public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent);
}
