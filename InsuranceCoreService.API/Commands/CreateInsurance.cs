using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    [Required(ErrorMessage = "Insurance number is required")]
    public string InsuranceNumber { get; set; } = null!;

    [Required(ErrorMessage = "YearlyPremium is required")]
    public decimal YearlyPremium { get; set; } = 0;

    [Required(ErrorMessage = "InsurerId is required")]
    public int InsurerId { get; set; } = 0;

    [Required(ErrorMessage = "StartPeriod is required")]
    public DateTime StartPeriod { get; set; }

    [Required(ErrorMessage = "EndPeriod is required")]
    public DateTime EndPeriod { get; set; }

    [Required(ErrorMessage = "Coverage is required")]
    public int CoverageId { get; set; }
}