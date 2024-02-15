using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.InsuranceAggregate;

public class InsuranceNumber : ValueObject
{
    public string Number { get; private set; } = Generate();

    public InsuranceNumber() { }

    private static string Generate()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var number = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

        return number;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Number;
    }
}