using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.Handlers;

public class CreateInsurerHandler(IInsurerRepository repository, IMapper mapper) : IRequestHandler<CreateInsurer, CreateInsurerResponse>
{
    public async Task<CreateInsurerResponse> Handle(CreateInsurer request, CancellationToken cancellationToken)
    {
        var insurer = mapper.Map<Insurer>(request);
        var result = await repository.CreateInsurerAsync(insurer);

        return mapper.Map<CreateInsurerResponse>(result);
    }
}
