namespace InsuranceCoreService.Domain.InsuranceAggregate;

public class YearlyPremium(decimal amount)
{
    public decimal Amount { get; private set; } = amount;

    private static decimal Tax => 0.12M;

    public void GenerateYearlyPremium(decimal amount)
    {
        Amount += amount;
    }

    public void ApplyTax()
    {
        Amount += Amount * Tax;
    }
}