namespace InsuranceCoreService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(ILogger<InsuranceController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetInsuranceByIdAsync")]
    public async Task<InsuranceGetDto> GetInsuranceByIdAsync()
    {
        return new InsuranceGetDto();
    }
}