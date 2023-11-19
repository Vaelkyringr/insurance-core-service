namespace InsuranceCoreService.Domain.Aggregates.Insurance;

public class Insurance
{
    public Insurance(string insuranceNumber, decimal premium, Coverage coverages)
    {
        Id = new InsuranceId();
        YearlyPremium = premium;
        Coverage = coverages;
        InsuranceNumber = insuranceNumber;
    }

    private InsuranceId Id { get; }

    private decimal YearlyPremium { get; set; }

    private decimal MonthlyPremium => YearlyPremium / 12;

    private Coverage Coverage { get; set; }

    private string InsuranceNumber { get; set; }

    public void CalculatePremium()
    {
        YearlyPremium += Coverage.GetYearlyBaseCoverageCost();
    }
}