namespace InsuranceCoreService.API.Responses;

public class CreateInsurerResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string OrganizationNumber { get; set; } = null!;
}