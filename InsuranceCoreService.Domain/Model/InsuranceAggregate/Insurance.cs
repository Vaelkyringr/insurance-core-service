namespace InsuranceCoreService.Domain.Model.InsuranceAggregate;

public class Insurance
{
    private readonly string _insuranceNumber;
    private decimal _premium;
    private readonly List<Coverage> _coverages;

    public Insurance(string insuranceNumber, decimal premium, List<Coverage> coverages)
    {
        _premium = premium;
        _coverages = coverages;
        _insuranceNumber = insuranceNumber;
    }

    public string GetInsuranceNumber()
    {
        return _insuranceNumber;
    }

    public decimal GetPremium()
    {
        return Math.Round(_premium, 2);
    }

    public List<Coverage> GetCoverages()
    {
        return _coverages;
    }

    public void CalculatePremium()
    {
        _premium += _coverages.Sum(coverage => coverage.GetBaseCoverageCost());
    }
}