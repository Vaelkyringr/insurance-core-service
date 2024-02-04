using InsuranceCoreService.API.Responses.Insurance;

namespace InsuranceCoreService.API.Queries;

public class GetInsuranceByIdQuery : IRequest<GetInsuranceResponse>
{
    public int Id { get; set; }
}