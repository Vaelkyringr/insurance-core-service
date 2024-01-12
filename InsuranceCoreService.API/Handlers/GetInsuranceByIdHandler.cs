using InsuranceCoreService.API.Queries;
using InsuranceCoreService.Domain.Aggregates.Insurance;
using MediatR;

namespace InsuranceCoreService.API.Handlers;

public class GetInsuranceByIdHandler : IRequestHandler<GetInsuranceByIdQuery, InsuranceGetDto>
{
    private readonly IMapper _mapper;
    private readonly IInsuranceRepository _repository;

    public GetInsuranceByIdHandler(IInsuranceRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<InsuranceGetDto> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var insurance = await _repository.GetInsuranceByIdAsync(request.Id);
        return _mapper.Map<InsuranceGetDto>(insurance);
    }
}