using InsuranceCoreService.API.Responses;
using MediatR;

namespace InsuranceCoreService.API.Queries;

public class GetInsuranceByIdQuery : IRequest<GetInsuranceResponse>
{
    public int Id { get; set; }
}