namespace InsuranceCoreService.Domain.Model.InsuranceAggregate;

public class Coverage
{
    private readonly CoverageType _coverageType;

    public Coverage(CoverageType coverageType)
    {
        _coverageType = coverageType;
    }

    public decimal GetBaseCoverageCost()
    {
        return _coverageType switch
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