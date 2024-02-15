using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Queries;

public class GetInsuranceByIdQuery : IRequest<GetInsuranceResponse>
{
    [Required(ErrorMessage = "Id is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
    public int Id { get; init; }
}