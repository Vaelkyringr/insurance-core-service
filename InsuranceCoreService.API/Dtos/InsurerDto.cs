namespace InsuranceCoreService.API.Dtos;

public class InsurerDto
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    public string OrganizationNumber { get; init; } = null!;

    public string Address { get; init; } = null!;
}