using InsuranceCoreService.Domain;

namespace InsuranceCoreService.Infrastructure.Services;

public interface IMessagePublisherService
{
    void Publish(string message);
}