namespace InsuranceCoreService.API.Dtos;

public class CoverageDto
{
    public string Name { get; init; } = null!;

    public string CoverageType { get; init; } = null!;

    public decimal BaseAmount { get; init; }
}
