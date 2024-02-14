using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Dtos;
using InsuranceCoreService.API.Responses;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.General;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateInsurance, Insurance>();
        CreateMap<Insurance, CreateInsuranceResponse>();
        CreateMap<Insurance, GetInsuranceResponse>();

        CreateMap<CreateInsurer, Insurer>();
        CreateMap<Insurer, InsurerDto>();
        CreateMap<Insurer, GetInsurersResponse>();
        CreateMap<Insurer, CreateInsurerResponse>();
        CreateMap<CreateInsurerResponse, Insurer>();

        CreateMap<Coverage, CoverageDto>();
    }
};