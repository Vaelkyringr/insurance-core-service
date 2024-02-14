using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.API.Handlers;

public class CreateInsuranceHandler(IInsuranceRepository insuranceRepository, ICoverageRepository coverageRepository, IMapper mapper) : IRequestHandler<CreateInsurance, CreateInsuranceResponse>
{
    public async Task<CreateInsuranceResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
    {
        var coverage = await coverageRepository.GetCoverageByIdAsync(request.CoverageId);
        var insurance = mapper.Map<Insurance>(request);

        if (coverage != null)
            insurance.Coverages = new List<Coverage> { coverage };

        var result = await insuranceRepository.CreateInsuranceAsync(insurance);

        return mapper.Map<CreateInsuranceResponse>(result);
    }
}