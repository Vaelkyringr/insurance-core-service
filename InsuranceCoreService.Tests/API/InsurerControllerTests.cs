using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

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
    public async Task GetAllInsurersAsync_ReturnsOkResult_WhenModelStateIsValid()
    {
        // Arrange
        var query = new GetInsurers();
        var response = new GetInsurersResponse();
        _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(response);

        // Act
        var result = await _controller.GetAllInsurersAsync(query);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Same(response, okResult.Value);
    }

    [Fact]
    public async Task CreateInsurerAsync_ReturnsCreatedAtActionResult_WhenModelStateIsValid()
    {
        // Arrange
        var command = new CreateInsurer();
        var response = new CreateInsurerResponse { Id = 1 };
        _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(response);

        // Act
        var result = await _controller.CreateInsurerAsync(command);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Same(response, createdAtActionResult.Value);
    }
}