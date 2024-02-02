namespace InsuranceCoreService.Domain.InsuranceAggregate;

using InsuranceCoreService.Domain.InsurerAggregate;

public class Insurance : EntityBase
{
    public Insurance() { }

    public Insurance(string insuranceNumber, decimal premium)
    {
        YearlyPremium = premium;
        InsuranceNumber = insuranceNumber;
        Created = DateTime.UtcNow;
    }

    public string InsuranceNumber { get; set; }

    public decimal YearlyPremium { get; set; }

    public int InsurerId { get; set; }

    public Insurer Insurer { get; set; }
}