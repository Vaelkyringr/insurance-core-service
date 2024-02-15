using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.InsuranceAggregate;

public class Insurance : EntityBase
{
    public Insurance() { }

    public InsuranceNumber InsuranceNumber { get; set; } = null!;

    public YearlyPremium YearlyPremium { get; set; } = null!;
    public int InsurerId { get; init; }
    public DateTime StartPeriod { get; init; }
    public DateTime EndPeriod { get; init; }

    public Insurer Insurer { get; init; } = null!;
    public ICollection<Coverage> Coverages { get; init; } = [];

    public void AddCoverage(Coverage coverage)
    {
        Coverages.Add(coverage);
    }
}