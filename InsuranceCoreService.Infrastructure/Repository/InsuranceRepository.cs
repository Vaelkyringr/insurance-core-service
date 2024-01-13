﻿using InsuranceCoreService.Domain.Aggregates.Insurance;
using InsuranceCoreService.Infrastructure.Context;

namespace InsuranceCoreService.Infrastructure.Repository;

public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{

    public InsuranceRepository(InsuranceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Insurance> GetInsuranceByIdAsync(int insuranceId)
    {
        return await GetByIdAsync(insuranceId);
    }
}