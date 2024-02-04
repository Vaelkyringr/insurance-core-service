using InsuranceCoreService.Domain.InsurerAggregate;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class InsurerRepository : Repository<Insurer>, IInsurerRepository
{
    public InsurerRepository(InsuranceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Insurer> CreateInsurerAsync(Insurer insurer)
    {
        return await AddAsync(insurer);
    }
}
