using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurance : IRequest<CreateInsuranceResponse>
{
    [Required(ErrorMessage = "Insurance number is required")]
    public string InsuranceNumber { get; set; } = null!;

    [Range(10, double.MaxValue, ErrorMessage = "Yearly premium must be greater than 10")]
    public decimal YearlyPremium { get; set; } = 0;

    [Required(ErrorMessage = "InsurerId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "InsurerId must be greater than 0")]
    public int InsurerId { get; set; }
}
