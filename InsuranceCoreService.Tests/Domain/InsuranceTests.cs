using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Tests.Domain;

public class InsuranceTests
{
    [Fact]
    public void Insurance_Contains_AddedCoverage()
    {
        var insurance = new Insurance();
        var coverage = new Coverage();

        insurance.AddCoverage(coverage);

        Assert.Contains(coverage, insurance.Coverages);
    }
}