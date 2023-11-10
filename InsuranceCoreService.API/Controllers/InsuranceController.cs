namespace InsuranceCoreService.API.Controllers;

public class InsuranceController : ControllerBase
{
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(ILogger<InsuranceController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetInsuranceByIdAsync")]
    public IEnumerable<WeatherForecast> Get()
    {
        return new List<WeatherForecast>();
    }
}