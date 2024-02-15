using InsuranceCoreService.API.Dtos;

namespace InsuranceCoreService.API.CQRS.Responses;

public class GetInsurersResponse
{
    public List<InsurerDto> Insurers { get; init; } = null!;
}