using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.API.Handlers;

public class CreateInsuranceHandler(IInsuranceRepository insuranceRepository, ICoverageRepository coverageRepository, IMapper mapper) : IRequestHandler<CreateInsurance, CreateInsuranceResponse>
{
    public async Task<CreateInsuranceResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
    {
        var coverages = await coverageRepository.GetCoveragesByIdsAsync(request.Coverages);
        var insurance = mapper.Map<Insurance>(request);

        // Generate insurance number
        insurance.InsuranceNumber = new InsuranceNumber();

        // Add coverages & calculate yearly premium
        foreach (var coverage in coverages)
        {
            insurance.AddCoverage(coverage);
            insurance.CalculateYearlyPremium(coverage.YearlyBaseAmount);
        }

        var result = await insuranceRepository.CreateInsuranceAsync(insurance);

        return mapper.Map<CreateInsuranceResponse>(result);
    }
}