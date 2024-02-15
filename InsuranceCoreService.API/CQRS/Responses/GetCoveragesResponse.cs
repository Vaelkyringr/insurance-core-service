using InsuranceCoreService.API.Dtos;

namespace InsuranceCoreService.API.CQRS.Responses;

public class GetCoveragesResponse
{
    public List<CoverageDto> Coverages { get; set; } = null!;
}