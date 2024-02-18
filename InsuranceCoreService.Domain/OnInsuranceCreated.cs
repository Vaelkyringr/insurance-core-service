using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain;

public class OnInsuranceCreated : IDomainEvent
{
    public OnInsuranceCreated(Insurance insurance)
    {
        Insurance = insurance;
        OccurredOn = DateTime.UtcNow;
    }

    public Insurance Insurance { get; }
    public DateTime OccurredOn { get; }
}