using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.API.CQRS.Commands;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    [Required(ErrorMessage = "YearlyPremium is required")]
    public decimal YearlyPremium { get; set; } = 0;

    [Required(ErrorMessage = "InsurerId is required")]
    public int InsurerId { get; set; } = 0;

    [Required(ErrorMessage = "StartPeriod is required")]
    public DateTime StartPeriod { get; set; }

    [Required(ErrorMessage = "EndPeriod is required")]
    public DateTime EndPeriod { get; set; }

    [Required(ErrorMessage = "Coverage is required")]
    public List<int> Coverages { get; set; } = null!;
}