namespace InsuranceCoreService.Domain.Aggregates.Insurance;

public class Insurance : EntityBase
{
    public Insurance() { }

    public Insurance(string insuranceNumber, decimal premium, Coverage coverages)
    {
        YearlyPremium = premium;
        Coverage = coverages;
        InsuranceNumber = insuranceNumber;
    }

    public string InsuranceNumber { get; set; }

    public decimal YearlyPremium { get; set; }

    private Coverage Coverage { get; set; }

    public void CalculatePremium()
    {
        YearlyPremium += Coverage.GetYearlyBaseCoverageCost();
    }
}