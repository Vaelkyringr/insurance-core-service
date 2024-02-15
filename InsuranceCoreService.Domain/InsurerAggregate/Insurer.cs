using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.SeedWork;

namespace InsuranceCoreService.Domain.InsurerAggregate;

public class Insurer : EntityBase
{
    public string Name { get; init; } = null!;

    public OrganizationNumber OrganizationNumber { get; set; } = null!;

    public string Address { get; init; } = null!;

    public ICollection<Insurance> Insurances { get; init; } = null!;
}