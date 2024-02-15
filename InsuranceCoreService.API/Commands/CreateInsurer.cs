using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurer : IRequest<CreateInsurerResponse>
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "OrganizationNumber is required")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "OrganizationNumber must be 10 characters long")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "OrganizationNumber must be numeric")]
    public string OrganizationNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;
}
