using InsuranceCoreService.API.Commands.Insurance;
using InsuranceCoreService.API.Responses.Insurance;
using InsuranceCoreService.Domain.InsuranceAggregate;

public class CreateInsuranceHandler : IRequestHandler<CreateInsurance, CreateInsuranceResponse>
{
    private readonly IInsuranceRepository _repository;

    public CreateInsuranceHandler(IInsuranceRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateInsuranceResponse> Handle(CreateInsurance request, CancellationToken cancellationToken)
    {
        var insurance = new Insurance(request.InsuranceNumber, request.YearlyPremium);
        await _repository.CreateInsuranceAsync(insurance);

        return new CreateInsuranceResponse()
        {
            InsuranceNumber = insurance.InsuranceNumber
        };
    }
}
