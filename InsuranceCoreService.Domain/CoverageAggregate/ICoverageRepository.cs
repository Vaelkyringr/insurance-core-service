namespace InsuranceCoreService.Domain.CoverageAggregate;

public interface ICoverageRepository
{
    Task<Coverage?> GetCoverageByIdAsync(int coverageId);
    Task<IEnumerable<Coverage>> GetCoveragesAsync(int pageIndex, int pageSize);
}