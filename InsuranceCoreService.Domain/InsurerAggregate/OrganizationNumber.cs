using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.InsurerAggregate;

public class OrganizationNumber : ValueObject
{
    public string Number { get; set; }

    public OrganizationNumber(string number)
    {
        if (!IsValid(number))
        {
            throw new ArgumentException("Invalid organization number.", nameof(number));
        }

        Number = number;
    }

    private static bool IsValid(string number)
    {
        return number.Length == 10;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Number;
    }
}