using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Infrastructure.Services;
using Newtonsoft.Json;

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

        var message = JsonConvert.SerializeObject(insurance);
        domainEventPublisher.Publish("Insurance", message);

        return mapper.Map<CreateInsuranceResponse>(result);
    }
}