using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsurerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<InsurerController> _logger;

    public InsurerController(IMediator mediator, ILogger<InsurerController> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("CreateInsurerAsync")]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInsurerAsync([FromBody] CreateInsurer command)
    {
        if (!ModelState.IsValid) 
        {
            _logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var response = await _mediator.Send(command);

        return CreatedAtAction("CreateInsurerAsync", new { id = response.Id }, response);
    }
}
