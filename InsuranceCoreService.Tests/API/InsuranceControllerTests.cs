using InsuranceCoreService.API.Controllers;
using InsuranceCoreService.API.Queries;
using InsuranceCoreService.API.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace InsuranceCoreService.Tests.API;

public class InsuranceControllerTests
{
    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsNotFound_WhenInsuranceIsNull()
    {
        const int insuranceId = 1;
        var mediator = new Mock<IMediator>();
        var logger = new Mock<ILogger<InsuranceController>>();
        mediator.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(() => null);
        
        var controller = new InsuranceController(mediator.Object, logger.Object);
        var result = await controller.GetInsuranceByIdAsync(insuranceId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetInsuranceByIdAsync_ReturnsOk_WhenInsuranceExists()
    {
        const int insuranceId = 1;
        var mediator = new Mock<IMediator>();
        var logger = new Mock<ILogger<InsuranceController>>();
        mediator.Setup(m => m.Send(It.IsAny<GetInsuranceByIdQuery>(), default)).ReturnsAsync(new GetInsuranceResponse {Id = insuranceId});

        var controller = new InsuranceController(mediator.Object, logger.Object);
        var result = await controller.GetInsuranceByIdAsync(insuranceId);

        var ok = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<GetInsuranceResponse>(ok.Value);

        Assert.Equal(1, response.Id);
    }
}