namespace InsuranceCoreService.API.Responses;

public class CreateInsuranceResponse
{
    public int Id { get; init; }

    public string InsuranceNumber { get; init; } = null!;

    public decimal YearlyPremium { get; init; }

    public DateTime Created { get; init; }
}
