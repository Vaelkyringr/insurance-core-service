using MediatR;

namespace InsuranceCoreService.API.Queries;

public class GetInsuranceByIdQuery : IRequest<InsuranceGetDto>
{
    public int Id { get; set; }
}