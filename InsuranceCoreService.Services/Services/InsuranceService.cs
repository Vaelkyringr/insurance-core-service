namespace InsuranceCoreService.Services.Services;

public class InsuranceService : IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;

    public InsuranceService(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }

    public async Task<Insurance> GetInsuranceByIdAsync(int insuranceId)
    {
        return await _insuranceRepository.GetInsuranceByIdAsync(insuranceId);
    }
}