using InsuranceCoreService.API.Responses.Insurance;

namespace InsuranceCoreService.API.Commands.Insurance;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    public string InsuranceNumber { get; set; } = null!;
    public decimal YearlyPremium { get; set; } = 0;
    public InsurerDto Insurer { get; set; } = null!;
}
