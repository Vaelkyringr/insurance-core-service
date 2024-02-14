using InsuranceCoreService.API.Responses;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCoreService.API.Queries;

public class GetCoverages : IRequest<GetCoveragesResponse>
{
    [Required(ErrorMessage = "PageIndex is required")]
    [Range(1, int.MaxValue, ErrorMessage = "PageIndex must be greater than 0")]
    public int PageIndex { get; set; }

    [Required(ErrorMessage = "PageSize is required")]
    [Range(1, int.MaxValue, ErrorMessage = "PageSize must be greater than 0")]
    public int PageSize { get; set; }
}