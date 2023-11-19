namespace InsuranceCoreService.Domain.Aggregates.Insurance;

public class Coverage
{
    public Coverage(CoverageType coverageType)
    {
        CoverageType = coverageType;
    }

    private CoverageType CoverageType { get; }

    public decimal GetYearlyBaseCoverageCost()
    {
        return CoverageType switch
        {
            CoverageType.Home => 200,
            CoverageType.Life => 1500,
            CoverageType.Health => 350,
            CoverageType.Motor => 200,
            CoverageType.Property => 150,
            CoverageType.Auto => 50,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}