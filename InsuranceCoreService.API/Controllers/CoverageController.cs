using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoverageController(IMediator mediator, ILogger<InsuranceController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<InsuranceController> _logger = logger;

    [HttpGet("GetAllCoveragesAsync")]
    public async Task<IActionResult> GetAllCoveragesAsync([FromBody] CreateInsurance command)
    {
        return Ok();
    }

    [HttpPost("AddCoveragesToInsuranceAsync")]
    public async Task<IActionResult> AddCoveragesToInsuranceAsync([FromBody] CreateInsurance command)
    {
        return Ok();
    }
}
