using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Tests.Domain;

public class YearlyPremiumTests
{
    [Fact]
    public void GenerateYearlyPremium_AddsCoverageAmount()
    {
        var yearlyPremium = new YearlyPremium(1000);
        yearlyPremium.GenerateYearlyPremium(500);

        Assert.Equal(1500, yearlyPremium.Amount);
    }

    [Fact]
    public void ApplyTax_IsSuccessfullyApplied()
    {
        var yearlyPremium = new YearlyPremium(1000);
        yearlyPremium.ApplyTax();

        Assert.Equal(1120, yearlyPremium.Amount);
    }
}
