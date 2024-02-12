using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain.InsurerAggregate;

public class Insurer : EntityBase
{
    public string Name { get; init; } = null!;

    public string OrganizationNumber { get; init; } = null!;

    public string Address { get; init; } = null!;

    public ICollection<Insurance> Insurances { get; init; } = null!;
}