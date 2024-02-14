using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class InsuranceRepository(InsuranceDbContext dbContext) : Repository<Insurance>(dbContext), IInsuranceRepository
{
    public async Task<Insurance?> GetInsuranceByIdAsync(int insuranceId)
    {
        return await GetByIdAsync(insuranceId);
    }

    public async Task<Insurance> CreateInsuranceAsync(Insurance insurance)
    {
        return await AddAsync(insurance);
    }
}