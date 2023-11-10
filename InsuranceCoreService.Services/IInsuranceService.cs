namespace InsuranceCoreService.Services;

public interface IInsuranceService
{
    object GetInsuranceByIdAsync(int insuranceId);
}
