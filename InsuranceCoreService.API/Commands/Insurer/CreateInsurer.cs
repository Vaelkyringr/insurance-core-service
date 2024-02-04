using InsuranceCoreService.API.Responses.Insurer;

namespace InsuranceCoreService.API.Commands.Insurer;

public class CreateInsurer : IRequest<CreateInsurerResponse>
{
    public string Name { get; set; } = null!;

    public string OrganizationNumber { get; set; } = null!;
}
