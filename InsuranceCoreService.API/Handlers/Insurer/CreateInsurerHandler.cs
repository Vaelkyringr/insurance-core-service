using InsuranceCoreService.API.Commands.Insurer;
using InsuranceCoreService.API.Responses.Insurer;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.Handlers.Insurer;

public class CreateInsurerHandler : IRequestHandler<CreateInsurer, CreateInsurerResponse>
{
    private readonly IInsurerRepository _repository;
    private readonly IMapper _mapper;

    public CreateInsurerHandler(IInsurerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateInsurerResponse> Handle(CreateInsurer request, CancellationToken cancellationToken)
    {
        var insurer = _mapper.Map<Domain.InsurerAggregate.Insurer>(request);
        var result = await _repository.CreateInsurerAsync(insurer);

        return _mapper.Map<CreateInsurerResponse>(result);
    }
}
