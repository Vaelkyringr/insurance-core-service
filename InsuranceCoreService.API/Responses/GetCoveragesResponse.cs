using InsuranceCoreService.API.Dtos;

namespace InsuranceCoreService.API.Responses;

public class GetCoveragesResponse
{
    public List<CoverageDto> Coverages { get; set; } = null!;
}