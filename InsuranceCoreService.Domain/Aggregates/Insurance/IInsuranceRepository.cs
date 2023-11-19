namespace InsuranceCoreService.Domain.Aggregates.Insurance;

public interface IInsuranceRepository
{
    Task<Insurance> GetInsuranceByIdAsync(int insuranceId);
}