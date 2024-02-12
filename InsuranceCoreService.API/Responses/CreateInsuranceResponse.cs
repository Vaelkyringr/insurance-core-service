namespace InsuranceCoreService.API.Responses;

public class CreateInsuranceResponse
{
    public int Id { get; init; }

    public string InsuranceNumber { get; init; } = null!;

    public decimal YearlyPremium { get; init; }

    public int InsurerId { get; set; }

    public DateTime StartPeriod { get; set; }

    public DateTime EndPeriod { get; set; }
}
