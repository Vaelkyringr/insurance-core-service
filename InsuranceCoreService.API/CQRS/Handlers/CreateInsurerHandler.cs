using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.CQRS.Handlers;

public class CreateInsurerHandler(IInsurerRepository repository, IMapper mapper) : IRequestHandler<CreateInsurer, CreateInsurerResponse>
{
    public async Task<CreateInsurerResponse> Handle(CreateInsurer request, CancellationToken cancellationToken)
    {
        var insurer = mapper.Map<Insurer>(request);
        insurer.OrganizationNumber = new OrganizationNumber(request.OrganizationNumber);

        var result = await repository.CreateInsurerAsync(insurer);

        return mapper.Map<CreateInsurerResponse>(result);
    }
}
