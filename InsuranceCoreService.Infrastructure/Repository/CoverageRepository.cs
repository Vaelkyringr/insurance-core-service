using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class CoverageRepository(InsuranceDbContext dbContext) : Repository<Coverage>(dbContext), ICoverageRepository
{
    public async Task<IEnumerable<Coverage>> GetCoveragesByIdsAsync(List<int> ids)
    {
        return await dbContext.Coverages
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<Coverage>> GetCoveragesAsync(int pageIndex, int pageSize)
    {
        return await GetAllAsync(pageIndex, pageSize);
    }
}