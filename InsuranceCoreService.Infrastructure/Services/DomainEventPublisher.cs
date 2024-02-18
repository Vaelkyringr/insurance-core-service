using InsuranceCoreService.Domain;

namespace InsuranceCoreService.Infrastructure.Services;

public class DomainEventPublisher : IDomainEventPublisher
{
    // ... constructor to initialize Azure Service Bus client ...

    public async Task PublishAsync(IDomainEvent domainEvent)
    {
        //var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(domainEvent)));
        //await _serviceBusClient.SendAsync(message);
    }
}