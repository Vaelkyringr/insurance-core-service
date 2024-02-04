using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(IMediator mediator, ILogger<InsuranceController> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("GetInsuranceByIdAsync")]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInsuranceByIdAsync(int insuranceId)
    {
        if (insuranceId <= 0)
        {
            ModelState.AddModelError(nameof(insuranceId), "InsuranceId must be greater than 0.");
        }

        if (ModelState.IsValid)
        {
            var insurance = await _mediator.Send(new GetInsuranceByIdQuery { Id = insuranceId });
            return insurance == null ? NotFound() : Ok(insurance);
        }

        _logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));

        return BadRequest(ModelState);
    }

    [HttpPost("CreateInsuranceAsync")]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<CreateInsurerResponse>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInsuranceAsync([FromBody] CreateInsurance command)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("{Errors}", ModelState.Values.SelectMany(v => v.Errors));
            return BadRequest(ModelState);
        }

        var response = await _mediator.Send(command);

        return CreatedAtAction("CreateInsuranceAsync", new { id = response.Id }, response);
    }
}