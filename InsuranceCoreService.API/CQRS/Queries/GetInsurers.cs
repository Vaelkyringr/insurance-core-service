using InsuranceCoreService.API.CQRS.Responses;

namespace InsuranceCoreService.API.CQRS.Queries;

public class GetInsurers : IRequest<GetInsurersResponse>
{
    [Required(ErrorMessage = "PageIndex is required")]
    [Range(1, int.MaxValue, ErrorMessage = "PageIndex must be greater than 0")]
    public int PageIndex { get; set; }

    [Required(ErrorMessage = "PageSize is required")]
    [Range(1, int.MaxValue, ErrorMessage = "PageSize must be greater than 0")]
    public int PageSize { get; set; }
}