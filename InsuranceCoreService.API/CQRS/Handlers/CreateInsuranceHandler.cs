using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.Domain;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Infrastructure.Services;

namespace InsuranceCoreService.API.CQRS.Handlers;

public class CreateInsuranceHandler(
    IInsuranceRepository insuranceRepository,
    ICoverageRepository coverageRepository,
    IDomainEventPublisher domainEventPublisher,
    IMapper mapper) :
    IRequestHandler<CreateInsurance, CreateInsuranceResponse>
{
    public async Task<CreateInsuranceResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
    {
        var coverages = await coverageRepository.GetCoveragesByIdsAsync(request.Coverages);
        var insurance = mapper.Map<Insurance>(request);

        // Generate insurance number & premiums
        insurance.InsuranceNumber = new InsuranceNumber();
        insurance.YearlyPremium = new YearlyPremium(request.YearlyPremium);

        // Add coverages, calculate yearly premium & tax
        foreach (var coverage in coverages)
        {
            insurance.AddCoverage(coverage);
            insurance.YearlyPremium.GenerateYearlyPremium(coverage.YearlyBaseAmount);
        }

        insurance.YearlyPremium.ApplyTax();

        // Save insurance & publish event to queue
        var result = await insuranceRepository.CreateInsuranceAsync(insurance);
        insurance.AddDomainEvent(new OnInsuranceCreated(insurance));

        foreach (var domainEvent in insurance.DomainEvents)
        {
            await domainEventPublisher.Publish(domainEvent);
        }

        insurance.ClearEvents();

        return mapper.Map<CreateInsuranceResponse>(result);
    }
}