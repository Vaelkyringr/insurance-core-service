using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class InsurerRepository(InsuranceDbContext dbContext) : Repository<Insurer>(dbContext), IInsurerRepository
{
    public async Task<Insurer> CreateInsurerAsync(Insurer insurer)
    {
        return await AddAsync(insurer);
    }

    public async Task<IEnumerable<Insurer>> GetAllInsurersAsync(int pageIndex, int pageSize)
    {
        return await GetAllAsync(pageIndex, pageSize);
    }

    public async Task<Insurer?> GetInsurerByIdAsync(int id)
    {
        return await GetByIdAsync(id);
    }
}
