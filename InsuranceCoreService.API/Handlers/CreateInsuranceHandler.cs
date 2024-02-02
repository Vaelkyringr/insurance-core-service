using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;

public class CreateInsuranceHandler : IRequestHandler<CreateInsuranceCommand, CreateInsuranceResponse>
{
    private readonly IInsuranceRepository _repository;

    public CreateInsuranceHandler(IInsuranceRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateInsuranceResponse> Handle(CreateInsuranceCommand request, CancellationToken cancellationToken)
    {
        var insurance = new Insurance(request.InsuranceNumber, request.Premium);
        await _repository.CreateInsuranceAsync(insurance);

        return new CreateInsuranceResponse()
        {
            InsuranceNumber = insurance.InsuranceNumber
        };
    }
}
