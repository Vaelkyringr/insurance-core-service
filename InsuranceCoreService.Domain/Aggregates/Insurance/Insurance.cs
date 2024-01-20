namespace InsuranceCoreService.Domain.Aggregates.Insurance;

public class Insurance : EntityBase
{
    public Insurance() { }

    public Insurance(string insuranceNumber, decimal premium)
    {
        YearlyPremium = premium;
        InsuranceNumber = insuranceNumber;
        Created = DateTime.UtcNow;
    }

    public int InsurerId { get; set; }

    public string InsuranceNumber { get; }

    private decimal YearlyPremium { get; }

    public Aggregates.Insurer.Insurer Insurer { get; set; }

    public void CalculatePremium()
    {
        //YearlyPremium += Coverage.GetYearlyBaseCoverageCost();
    }
}