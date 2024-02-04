namespace InsuranceCoreService.Domain.InsuranceAggregate;

using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

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

    public string InsuranceNumber { get; set; }
    public decimal YearlyPremium { get; set; }
    public int InsurerId { get; set; }

    public Insurer Insurer { get; set; }
    public ICollection<Coverage> Coverages { get; set; }
    public ICollection<InsuranceCoverage> InsuranceCoverages { get; set; }
}