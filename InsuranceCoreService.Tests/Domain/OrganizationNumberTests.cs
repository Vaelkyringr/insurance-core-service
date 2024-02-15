using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.Tests.Domain;

public class OrganizationNumberTests
{
    [Fact]
    public void TestValidOrganizationNumber()
    {
        const string number = "1234567890";
        var organizationNumber = new OrganizationNumber(number);

        Assert.Equal(number, organizationNumber.Number);
    }

    [Fact]
    public void TestInvalidOrganizationNumber()
    {
        const string number = "12345";

        Assert.Throws<ArgumentException>(() => new OrganizationNumber(number));
    }
}