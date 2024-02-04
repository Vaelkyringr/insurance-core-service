namespace InsuranceCoreService.Domain.CoverageAggregate;

public class Coverage : EntityBase
{
    public Coverage() { }

    public string Name { get; set; } = null!;
    public ICollection<InsuranceCoverage> InsuranceCoverages { get; set; } = null!;
}