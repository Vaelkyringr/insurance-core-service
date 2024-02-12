namespace InsuranceCoreService.API.Responses;

public class GetInsuranceResponse
{
    public int Id { get; set; }

    public string? InsuranceNumber { get; set; }

    public decimal YearlyPremium { get; set; }

    public DateTime StartPeriod { get; set; }

    public DateTime EndPeriod { get; set; }
}