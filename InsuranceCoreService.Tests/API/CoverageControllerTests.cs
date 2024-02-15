using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;

namespace InsuranceCoreService.Tests.API;

public class CoverageControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<CoverageController>> _loggerMock;
    private readonly CoverageController _controller;

    public CoverageControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<CoverageController>>();
        _controller = new CoverageController(_mediatorMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetAllCoveragesAsync_ReturnsOk_WhenCalled()
    {
        var query = new GetCoverages();
        var response = new GetCoveragesResponse();
        _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(response);

        var result = await _controller.GetAllCoveragesAsync(query);
        var okResult = Assert.IsType<OkObjectResult>(result);

        Assert.Same(response, okResult.Value);
    }

    [Fact]
    public async Task GetAllCoveragesAsync_ReturnsBadRequestResult_WhenModelStateIsInvalid()
    {
        var query = new GetCoverages { PageIndex = 0, PageSize = 0 };

        _controller.ModelState.AddModelError("PageIndex", "PageIndex must be greater than 0");
        _controller.ModelState.AddModelError("PageSize", "PageSize must be greater than 0");

        var result = await _controller.GetAllCoveragesAsync(query);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}