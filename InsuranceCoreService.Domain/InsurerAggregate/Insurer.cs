using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain.InsurerAggregate;

public class Insurer : EntityBase
{
    public string Name { get; set; } = null!;

    public string OrganizationNumber { get; set; } = null!;

    public ICollection<Insurance> Insurances { get; set; } = null!;
}
