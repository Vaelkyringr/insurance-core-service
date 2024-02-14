using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.API.Handlers;

public class GetInsuranceHandler(IInsuranceRepository repository, IMapper mapper) : IRequestHandler<GetInsuranceByIdQuery, GetInsuranceResponse>
{
    public async Task<GetInsuranceResponse> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var insurance = await repository.GetInsuranceByIdAsync(request.Id);
        return mapper.Map<GetInsuranceResponse>(insurance);
    }
}