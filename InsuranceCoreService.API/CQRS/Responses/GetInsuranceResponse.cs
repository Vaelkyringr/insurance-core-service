namespace InsuranceCoreService.API.CQRS.Responses;

public class GetInsuranceResponse
{
    public int Id { get; init; }

    public string? InsuranceNumber { get; init; }

    public decimal YearlyPremium { get; init; }

    public DateTime StartPeriod { get; init; }

    public DateTime EndPeriod { get; init; }
}