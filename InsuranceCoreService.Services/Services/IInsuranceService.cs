namespace InsuranceCoreService.Services.Services;

public interface IInsuranceService
{
    Task<Insurance> GetInsuranceByIdAsync(int insuranceId);
}
