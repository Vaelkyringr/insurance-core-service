namespace InsuranceCoreService.Domain.Model.InsuranceAggregate;

public interface IInsuranceRepository
{
    Task<Insurance> GetInsuranceByIdAsync(int insuranceId);
}