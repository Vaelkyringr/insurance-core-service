using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;

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
    public async Task GetInsuranceByIdAsync_ReturnsNotFoundResult_WhenInsuranceIsNull()
    {
        // Arrange
        int insuranceId = 1;
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(() => null);

        // Act
        var result = await _controller.GetInsuranceByIdAsync(insuranceId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsOkResult_WhenInsuranceExists()
    {
        // Arrange
        int insuranceId = 1;
        var insurance = new Insurance();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(new GetInsuranceResponse());

        // Act
        var result = await _controller.GetInsuranceByIdAsync(insuranceId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Same(insurance, okResult.Value);
    }

    [Fact]
    public async Task CreateInsuranceAsync_ReturnsCreatedAtActionResult_WhenModelStateIsValid()
    {
        // Arrange
        var command = new CreateInsurance();
        var response = new CreateInsuranceResponse { Id = 1 };
        _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(response);

        // Act
        var result = await _controller.CreateInsuranceAsync(command);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Same(response, createdAtActionResult.Value);
    }
}