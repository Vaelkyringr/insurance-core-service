using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoverageController(IMediator mediator, ILogger<CoverageController> logger) : ControllerBase
{
    [HttpGet("GetAllCoveragesAsync")]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<GetCoveragesResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCoveragesAsync([FromQuery] GetCoverages query)
    {
        if (!ModelState.IsValid)
        {
            logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var result = await mediator.Send(query);
        return Ok(result);
    }
}