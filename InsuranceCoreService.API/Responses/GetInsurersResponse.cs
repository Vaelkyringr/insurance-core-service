using InsuranceCoreService.API.Dtos;

namespace InsuranceCoreService.API.Responses;

public class GetInsurersResponse
{
    public List<InsurerDto> Insurers { get; init; } = null!;
}