using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.API.Dtos;
using InsuranceCoreService.Domain.CoverageAggregate;

namespace InsuranceCoreService.API.CQRS.Handlers;

public class GetCoveragesHandler(ICoverageRepository repository, IMapper mapper) : IRequestHandler<GetCoverages, GetCoveragesResponse>
{
    public async Task<GetCoveragesResponse> Handle(GetCoverages request, CancellationToken cancellationToken)
    {
        var coverages = await repository.GetCoveragesAsync(request.PageIndex, request.PageSize);

        return new GetCoveragesResponse
        {
            Coverages = mapper.Map<List<CoverageDto>>(coverages)
        };
    }
}