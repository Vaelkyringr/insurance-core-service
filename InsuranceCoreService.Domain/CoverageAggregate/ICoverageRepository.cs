namespace InsuranceCoreService.Domain.CoverageAggregate;

public interface ICoverageRepository
{
    Task<IEnumerable<Coverage>> GetCoveragesByIdsAsync(List<int> ids);
    Task<IEnumerable<Coverage>> GetCoveragesAsync(int pageIndex, int pageSize);
}