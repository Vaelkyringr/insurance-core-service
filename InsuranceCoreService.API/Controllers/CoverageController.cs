using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoverageController(IMediator mediator, ILogger<InsuranceController> logger) : ControllerBase
{
    [HttpGet("GetAllCoveragesAsync")]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCoveragesAsync([FromQuery] GetCoverages query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
}