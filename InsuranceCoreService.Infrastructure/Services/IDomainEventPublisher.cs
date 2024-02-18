using InsuranceCoreService.Domain;

namespace InsuranceCoreService.Infrastructure.Services;

public interface IDomainEventPublisher
{
    void Publish(string queueName, string message);
}