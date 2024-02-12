namespace InsuranceCoreService.Domain.InsuranceAggregate;

using CoverageAggregate;
using InsurerAggregate;

public class Insurance : EntityBase
{
    public Insurance()
    {
        Coverages = new List<Coverage>();
    }

    public Insurance(string insuranceNumber, decimal yearlyPremium)
    {
        YearlyPremium = yearlyPremium;
        InsuranceNumber = insuranceNumber;
        Created = DateTime.UtcNow;
        Coverages = new List<Coverage>();
    }

    public string InsuranceNumber { get; set; } = null!;
    public decimal YearlyPremium { get; set; }
    public int InsurerId { get; set; }
    public DateTime StartPeriod { get; set; }
    public DateTime EndPeriod { get; set; }

    public Insurer Insurer { get; set; } = null!;
    public ICollection<Coverage> Coverages { get; set; }
    public ICollection<InsuranceCoverage> InsuranceCoverages { get; set; } = null!;
}