using InsuranceCoreService.API.Dtos;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.Handlers;

public class GetInsurersHandler(IInsurerRepository repository, IMapper mapper) : IRequestHandler<GetInsurers, GetInsurersResponse>
{
    public async Task<GetInsurersResponse> Handle(GetInsurers request, CancellationToken cancellationToken)
    {
        var insurers = await repository.GetAllInsurersAsync(request.PageIndex, request.PageSize);

        return new GetInsurersResponse
        {
            Insurers = mapper.Map<List<InsurerDto>>(insurers)
        };
    }
}