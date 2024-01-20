using InsuranceCoreService.API.Responses;
using MediatR;

namespace InsuranceCoreService.API.Commands;

public class CreateInsuranceCommand : IRequest<CreateInsuranceResponse>
{
    public string InsuranceNumber { get; set; } = null!;
    public decimal Premium { get; internal set; }
    private decimal YearlyPremium { get; set; } = 0;
}
