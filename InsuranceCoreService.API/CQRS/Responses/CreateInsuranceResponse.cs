namespace InsuranceCoreService.API.CQRS.Responses;

public class CreateInsuranceResponse
{
    public int Id { get; init; }

    public string InsuranceNumber { get; init; } = null!;

    public decimal YearlyPremium { get; init; }

    public int InsurerId { get; init; }

    public DateTime StartPeriod { get; init; }

    public DateTime EndPeriod { get; init; }
}
