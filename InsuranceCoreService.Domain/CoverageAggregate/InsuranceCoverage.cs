using InsuranceCoreService.Domain.InsuranceAggregate;

namespace InsuranceCoreService.Domain.CoverageAggregate;

public class InsuranceCoverage : EntityBase
{
    public InsuranceCoverage() { }

    public int InsuranceId { get; set; }
    public Insurance Insurance { get; set; }

    public int CoverageId { get; set; }
    public Coverage Coverage { get; set; }
}
