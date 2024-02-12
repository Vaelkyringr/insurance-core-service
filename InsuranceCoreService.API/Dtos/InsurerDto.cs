namespace InsuranceCoreService.API.Dtos;

public class InsurerDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string OrganizationNumber { get; set; } = null!;

    public string Address { get; set; } = null!;
}