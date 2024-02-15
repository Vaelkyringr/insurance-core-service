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
        CreateMap<CreateInsurance, Insurance>()
            .ForMember(dest => dest.Coverages, opt => opt.Ignore())
            .ForMember(dest => dest.YearlyPremium, opt => opt.Ignore());
        CreateMap<Insurance, CreateInsuranceResponse>()
            .ForMember(dest => dest.YearlyPremium, opt => opt.MapFrom(x => x.YearlyPremium.Amount))
            .ForMember(dest => dest.InsuranceNumber, opt => opt.MapFrom(x => x.InsuranceNumber.Number));
        CreateMap<Insurance, GetInsuranceResponse>();

        CreateMap<CreateInsurer, Insurer>().ForMember(dest => dest.OrganizationNumber, opt => opt.Ignore());
        CreateMap<Insurer, InsurerDto>();
        CreateMap<Insurer, GetInsurersResponse>();
        CreateMap<Insurer, CreateInsurerResponse>();
        CreateMap<CreateInsurerResponse, Insurer>();

        CreateMap<Coverage, CoverageDto>();
    }
};