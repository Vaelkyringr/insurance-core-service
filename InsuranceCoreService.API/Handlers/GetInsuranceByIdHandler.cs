using InsuranceCoreService.API.Queries;
using InsuranceCoreService.Domain.Aggregates.Insurance;
using MediatR;

namespace InsuranceCoreService.API.Handlers;

public class GetInsuranceByIdHandler : IRequestHandler<GetInsuranceByIdQuery, InsuranceGetDto>
{
    private readonly IInsuranceRepository _repository;

    public GetInsuranceByIdHandler(IInsuranceRepository repository)
    {
        _repository = repository;
    }

    public async Task<InsuranceGetDto> Handle(GetInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var insurance = await _repository.GetInsuranceByIdAsync(request.Id);
        return new InsuranceGetDto();
    }
}