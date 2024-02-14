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
        insurance.Coverages = coverages.ToList();
        
        var result = await insuranceRepository.CreateInsuranceAsync(insurance);

        return mapper.Map<CreateInsuranceResponse>(result);
    }
}