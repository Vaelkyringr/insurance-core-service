namespace InsuranceCoreService.Domain.InsuranceAggregate;

public interface IInsuranceRepository
{
    Task<Insurance> GetInsuranceByIdAsync(int insuranceId);

    Task CreateInsuranceAsync(Insurance insurance);
}