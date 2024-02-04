using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.API.Handlers;

public class CreateInsuranceHandler : IRequestHandler<CreateInsurance, CreateInsuranceResponse>
{
    private readonly IInsuranceRepository _repository;
    private readonly IMapper _mapper;

    public CreateInsuranceHandler(IInsuranceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateInsuranceResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
    {
        var insurance = _mapper.Map<Insurance>(request);

        await _repository.CreateInsuranceAsync(insurance);

        return new CreateInsuranceResponse()
        {
            InsuranceNumber = insurance.InsuranceNumber
        };
    }
}
