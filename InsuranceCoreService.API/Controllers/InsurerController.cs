using InsuranceCoreService.API.Commands.Insurer;
using InsuranceCoreService.API.Responses.Insurer;

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
    public async Task<IActionResult> CreateInsurerAsync([FromBody] CreateInsurer command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction("CreateInsurerAsync", new { id = response.Id }, response);
    }
}
