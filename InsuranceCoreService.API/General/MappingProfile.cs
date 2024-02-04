using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.General;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateInsurance, Insurance>();
        CreateMap<Insurance, GetInsuranceResponse>();

        CreateMap<CreateInsurer, Insurer>();
        CreateMap<CreateInsurerResponse, Insurer>();
        CreateMap<Insurer, CreateInsurerResponse>();
    }
}