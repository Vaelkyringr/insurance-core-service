using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;
using MediatR;

namespace InsuranceCoreService.API.Handlers;

public class GetInsuranceHandler : IRequestHandler<GetInsuranceByIdQuery, GetInsuranceResponse>
{
    private readonly IMapper _mapper;
    private readonly IInsuranceRepository _repository;

    public GetInsuranceHandler(IInsuranceRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetInsuranceResponse> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var insurance = await _repository.GetInsuranceByIdAsync(request.Id);
        return _mapper.Map<GetInsuranceResponse>(insurance);
    }
}