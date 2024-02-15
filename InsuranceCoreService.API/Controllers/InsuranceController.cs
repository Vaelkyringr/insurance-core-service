using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController(IMediator mediator, ILogger<InsuranceController> logger) : ControllerBase
{
    [HttpGet("GetInsuranceByIdAsync")]
    [ProducesResponseType<GetInsuranceResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<GetInsuranceResponse>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<GetInsuranceResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInsuranceByIdAsync([FromQuery] GetInsuranceByIdQuery query)
    {
        if (!ModelState.IsValid)
        {
            logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var insurance = await mediator.Send(query);
        
        if (insurance == null)
            return NotFound();

        return Ok(insurance);
    }

    [HttpPost("CreateInsuranceAsync")]
    [ProducesResponseType<CreateInsuranceResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<CreateInsuranceResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInsuranceAsync([FromBody] CreateInsurance command)
    {
        if (!ModelState.IsValid)
        {
            logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var response = await mediator.Send(command);

        return CreatedAtAction("CreateInsuranceAsync", new { id = response.Id }, response);
    }
}