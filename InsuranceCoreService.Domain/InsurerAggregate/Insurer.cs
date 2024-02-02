using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain.InsurerAggregate;

public class Insurer : EntityBase
{
    public string Name { get; set; }

    public string OrganizationNumber { get; set; }

    public ICollection<Insurance> Insurances { get; set; }
}
