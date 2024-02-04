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
    public async Task<IActionResult> GetInsuranceByIdAsync(int insuranceId)
    {
        var insurance = await _mediator.Send(new GetInsuranceByIdQuery { Id = insuranceId });
        return insurance == null ? NotFound() : Ok(insurance);
    }

    [HttpPost("CreateInsuranceAsync")]
    public async Task<IActionResult> CreateInsuranceAsync([FromBody] CreateInsurance command)
    {
        CreateInsuranceResponse response;

        try
        {
            response = await _mediator.Send(command);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(response);
    }
}