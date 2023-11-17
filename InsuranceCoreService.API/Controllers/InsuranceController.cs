namespace InsuranceCoreService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IInsuranceService _insuranceService;
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(ILogger<InsuranceController> logger, IInsuranceService insuranceService, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _insuranceService = insuranceService;
    }

    [HttpGet("GetInsuranceByIdAsync")]
    public async Task<InsuranceGetDto> GetInsuranceByIdAsync(int insuranceId)
    {
        _logger.LogInformation("HTTP request received with id {InsuranceId}", insuranceId);

        
        var insurance = await _insuranceService.GetInsuranceByIdAsync(insuranceId);

        return _mapper.Map<InsuranceGetDto>(insurance);
    }
}