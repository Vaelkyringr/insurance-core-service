using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    public string InsuranceNumber { get; set; } = null!;
    public decimal YearlyPremium { get; set; } = 0;
    public InsurerDto Insurer { get; set; } = null!;
}
