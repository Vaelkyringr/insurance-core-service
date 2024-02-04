namespace InsuranceCoreService.API.Responses;

public class CreateInsuranceResponse
{
    public int Id { get; set; }

    public string InsuranceNumber { get; set; } = null!;

    public decimal YearlyPremium { get; set; } = 0;

    public DateTime Created { get; set; }
}
