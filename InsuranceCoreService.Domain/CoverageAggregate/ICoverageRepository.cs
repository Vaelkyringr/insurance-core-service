namespace InsuranceCoreService.Domain.CoverageAggregate;

public interface ICoverageRepository
{
    Task<IEnumerable<Coverage>> GetCoveragesAsync(int pageIndex, int pageSize);
}