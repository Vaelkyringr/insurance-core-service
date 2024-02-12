namespace InsuranceCoreService.API.Responses;

public class GetInsuranceResponse
{
    public int Id { get; init; }

    public string? InsuranceNumber { get; init; }

    public decimal YearlyPremium { get; init; }

    public DateTime StartPeriod { get; set; }

    public DateTime EndPeriod { get; set; }
}