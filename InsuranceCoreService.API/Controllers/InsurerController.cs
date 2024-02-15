using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsurerController(IMediator mediator, ILogger<InsurerController> logger) : ControllerBase
{
    [HttpGet("GetAllInsurersAsync")]
    [ProducesResponseType<GetInsurersResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<GetInsurersResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllInsurersAsync([FromQuery] GetInsurers query)
    {
        if (!ModelState.IsValid)
        {
            logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("CreateInsurerAsync")]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInsurerAsync([FromBody] CreateInsurer command)
    {
        if (!ModelState.IsValid) 
        {
            logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var response = await mediator.Send(command);

        return CreatedAtAction("CreateInsurerAsync", new { id = response.Id }, response);
    }
}