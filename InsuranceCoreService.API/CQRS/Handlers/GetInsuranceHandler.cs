using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.API.CQRS.Handlers;

public class GetInsuranceHandler(IInsuranceRepository repository, IMapper mapper) : IRequestHandler<GetInsuranceByIdQuery, GetInsuranceResponse>
{
    public async Task<GetInsuranceResponse> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var insurance = await repository.GetInsuranceByIdAsync(request.Id);
        return mapper.Map<GetInsuranceResponse>(insurance);
    }
}