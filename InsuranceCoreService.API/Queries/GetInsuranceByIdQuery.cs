using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Queries;

public class GetInsuranceByIdQuery : IRequest<GetInsuranceResponse>
{
    public int Id { get; set; }
}