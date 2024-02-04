using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    [Required(ErrorMessage = "Insurance number is required")]
    public string InsuranceNumber { get; set; } = null!;

    [Range(0, double.MaxValue, ErrorMessage = "Yearly premium must be greater than or equal to 0")]
    public decimal YearlyPremium { get; set; } = 0;

    [Required(ErrorMessage = "Insurer is required")]
    public InsurerDto Insurer { get; set; } = null!;
}
