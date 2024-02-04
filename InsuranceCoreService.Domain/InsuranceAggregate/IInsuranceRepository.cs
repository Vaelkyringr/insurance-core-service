namespace InsuranceCoreService.Domain.InsuranceAggregate;

public interface IInsuranceRepository
{
    Task<Insurance?> GetInsuranceByIdAsync(int insuranceId);

    Task<Insurance> CreateInsuranceAsync(Insurance insurance);
}