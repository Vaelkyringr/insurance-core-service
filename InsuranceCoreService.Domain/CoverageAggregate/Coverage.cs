namespace InsuranceCoreService.Domain.CoverageAggregate;

public class Coverage : EntityBase
{
    public Coverage() { }

    public string Name { get; set; }
    public ICollection<InsuranceCoverage> InsuranceCoverages { get; set; }
}