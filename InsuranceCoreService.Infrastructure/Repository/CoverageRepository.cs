using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class CoverageRepository(InsuranceDbContext dbContext) : Repository<Coverage>(dbContext), ICoverageRepository
{
    public async Task<Coverage?> GetCoverageByIdAsync(int coverageId)
    {
        return await GetByIdAsync(coverageId);
    }

    public async Task<IEnumerable<Coverage>> GetCoveragesAsync(int pageIndex, int pageSize)
    {
        return await GetAllAsync(pageIndex, pageSize);
    }
}