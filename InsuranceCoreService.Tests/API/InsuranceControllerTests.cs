using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.Tests.API;

public class InsuranceControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<InsuranceController>> _loggerMock;
    private readonly InsuranceController _controller;

    public InsuranceControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<InsuranceController>>();
        _controller = new InsuranceController(_mediatorMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        var query = new GetInsuranceByIdQuery { Id = 1 };
        _controller.ModelState.AddModelError("Id", "Id is required");

        var result = await _controller.GetInsuranceByIdAsync(query);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsNotFound_WhenInsuranceIsNull()
    {
        var query = new GetInsuranceByIdQuery { Id = 1 };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(() => null);
        var result = await _controller.GetInsuranceByIdAsync(query);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsOk_WhenInsuranceExists()
    {
        var query = new GetInsuranceByIdQuery { Id = 1 };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(new GetInsuranceResponse());

        var result = await _controller.GetInsuranceByIdAsync(query);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CreateInsuranceAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        var command = new CreateInsurance();
        _controller.ModelState.AddModelError("YearlyPremium", "The YearlyPremium field is required.");
        var result = await _controller.CreateInsuranceAsync(command);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task CreateInsuranceAsync_ReturnsCreatedAtAction_WhenModelStateIsValid()
    {
        var command = new CreateInsurance();
        _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(new CreateInsuranceResponse { Id = 1 });
        var result = await _controller.CreateInsuranceAsync(command);

        Assert.IsType<CreatedAtActionResult>(result);
    }
}