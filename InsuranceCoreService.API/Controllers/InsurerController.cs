using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsurerController(IMediator mediator, ILogger<InsurerController> logger) : ControllerBase
{
    [HttpGet("GetAllInsurersAsync")]
    public async Task<IActionResult> GetAllInsurersAsync([FromBody] CreateInsurer command)
    {
        return Ok();
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