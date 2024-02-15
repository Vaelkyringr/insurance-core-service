using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.Tests.API;

public class InsurerControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<InsurerController>> _loggerMock;
    private readonly InsurerController _controller;

    public InsurerControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<InsurerController>>();
        _controller = new InsurerController(_mediatorMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetAllInsurersAsync_ReturnsOk_WhenModelStateIsValid()
    {
        var query = new GetInsurers();
        var response = new GetInsurersResponse();

        _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(response);

        var result = await _controller.GetAllInsurersAsync(query);
        var okResult = Assert.IsType<OkObjectResult>(result);

        Assert.Same(response, okResult.Value);
    }

    [Fact]
    public async Task GetAllInsurersAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        var query = new GetInsurers { PageIndex = 0, PageSize = 0 };
        _controller.ModelState.AddModelError("PageIndex", "PageIndex must be greater than 0");
        _controller.ModelState.AddModelError("PageSize", "PageSize must be greater than 0");

        var result = await _controller.GetAllInsurersAsync(query);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task CreateInsurerAsync_ReturnsCreatedAtAction_WhenModelStateIsValid()
    {
        var command = new CreateInsurer();
        var response = new CreateInsurerResponse { Id = 1 };
        _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(response);

        var result = await _controller.CreateInsurerAsync(command);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);

        Assert.Same(response, createdAtActionResult.Value);
    }

    [Fact]
    public async Task CreateInsurerAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        var command = new CreateInsurer();
        _controller.ModelState.AddModelError("Name", "The Name field is required.");

        var result = await _controller.CreateInsurerAsync(command);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}