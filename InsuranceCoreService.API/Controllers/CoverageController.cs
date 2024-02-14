using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoverageController(IMediator mediator, ILogger<InsuranceController> logger) : ControllerBase
{
    [HttpGet("GetAllCoveragesAsync")]
    [HttpGet("GetInsuranceByIdAsync")]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCoveragesAsync([FromQuery] GetCoverages query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("AddCoveragesToInsuranceAsync")]
    public async Task<IActionResult> AddCoveragesToInsuranceAsync([FromBody] CreateInsurance command)
    {
        return Ok();
    }
}
