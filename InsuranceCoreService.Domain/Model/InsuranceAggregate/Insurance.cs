namespace InsuranceCoreService.Domain.Model.InsuranceAggregate;

public class Insurance
{
    private readonly InsuranceId _id;
    private decimal _yearlyPremium;
    private readonly Coverage _coverage;
    private readonly string _insuranceNumber;

    public Insurance(string insuranceNumber, decimal premium, Coverage coverages)
    {
        _id = new InsuranceId();
        _yearlyPremium = premium;
        _coverage = coverages;
        _insuranceNumber = insuranceNumber;
    }
    
    public Guid GetInsuranceId()
    {
        return _id.GetValue();
    }

    public string GetInsuranceNumber()
    {
        return _insuranceNumber;
    }

    public decimal GetYearlyPremium()
    {
        return Math.Round(_yearlyPremium, 2);
    }

    public decimal GetMonthlyPremium()
    {
        return Math.Round(_yearlyPremium / 12);
    }

    public Coverage GetCoverage()
    {
        return _coverage;
    }

    public void CalculatePremium()
    {
        _yearlyPremium += _coverage.GetYearlyBaseCoverageCost();
    }
}