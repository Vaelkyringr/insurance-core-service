using InsuranceCoreService.API.Commands.Insurer;
using InsuranceCoreService.API.Responses.Insurance;
using InsuranceCoreService.API.Responses.Insurer;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.General;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Insurance, GetInsuranceResponse>();
        CreateMap<Insurer, CreateInsurerResponse>();
        CreateMap<CreateInsurer, Insurer>();
        CreateMap<CreateInsurerResponse, Insurer>();
    }
}