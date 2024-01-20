using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.Aggregates.Insurance;

namespace InsuranceCoreService.API.General;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Insurance, GetInsuranceResponse>();
    }
}