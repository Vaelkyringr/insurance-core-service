namespace InsuranceCoreService.API.Responses;

public class CreateInsuranceResponse
{
    public string? InsuranceNumber { get; set; }

    public decimal YearlyPremium { get; set; } = 0;

    public DateTime Created { get; set; }
}
