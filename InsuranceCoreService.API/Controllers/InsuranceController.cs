namespace InsuranceCoreService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly ILogger<InsuranceController> _logger;
    private readonly IInsuranceService _insuranceService;

    public InsuranceController(ILogger<InsuranceController> logger, IInsuranceService insuranceService)
    {
        _logger = logger;
        _insuranceService = insuranceService;
    }

    [HttpGet("GetInsuranceByIdAsync")]
    public async Task<InsuranceGetDto> GetInsuranceByIdAsync(int insuranceId)
    {
        var insurance = _insuranceService.GetInsuranceByIdAsync(insuranceId);
        return new InsuranceGetDto();
    }
}