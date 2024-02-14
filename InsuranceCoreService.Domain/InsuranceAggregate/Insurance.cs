namespace InsuranceCoreService.Domain.InsuranceAggregate;

using CoverageAggregate;
using InsurerAggregate;

public class Insurance : EntityBase
{
    public Insurance() { }

    public string InsuranceNumber { get; init; } = null!;
    public decimal YearlyPremium { get; init; }
    public int InsurerId { get; init; }
    public DateTime StartPeriod { get; init; }
    public DateTime EndPeriod { get; init; }

    public Insurer Insurer { get; init; } = null!;
    public ICollection<Coverage> Coverages { get; set; } = [];
}