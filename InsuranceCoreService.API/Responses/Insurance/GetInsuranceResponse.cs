namespace InsuranceCoreService.API.Responses.Insurance;

public class GetInsuranceResponse
{
    public int Id { get; set; }

    public string? InsuranceNumber { get; set; }

    public decimal YearlyPremium { get; set; }

    public DateTime Created { get; set; }
}
