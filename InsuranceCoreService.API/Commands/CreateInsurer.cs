using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Commands;

public class CreateInsurer : IRequest<CreateInsurerResponse>
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "OrganizationNumber is required")]
    public string OrganizationNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;
}
