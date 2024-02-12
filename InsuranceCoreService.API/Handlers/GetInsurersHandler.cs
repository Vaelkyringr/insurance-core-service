using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.Handlers;

public class GetInsurersHandler(IInsurerRepository repository, IMapper mapper) : IRequestHandler<GetInsurers, GetInsurersResponse>
{
    public async Task<GetInsurersResponse> Handle(GetInsurers request, CancellationToken cancellationToken)
    {
        var insurance = await repository.GetAllInsurersAsync(request.PageIndex, request.PageSize);

        return mapper.Map<GetInsurersResponse>(insurance);
    }
}