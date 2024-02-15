using InsuranceCoreService.API.CQRS.Commands;
using InsuranceCoreService.API.CQRS.Queries;
using InsuranceCoreService.API.CQRS.Responses;
using InsuranceCoreService.API.Dtos;
using InsuranceCoreService.Domain.CoverageAggregate;
using InsuranceCoreService.Domain.InsuranceAggregate;
using InsuranceCoreService.Domain.InsurerAggregate;

namespace InsuranceCoreService.API.General;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Insurance
        CreateMap<CreateInsurance, Insurance>()
            .ForMember(dest => dest.Coverages, opt => opt.Ignore())
            .ForMember(dest => dest.YearlyPremium, opt => opt.Ignore());
        CreateMap<Insurance, CreateInsuranceResponse>()
            .ForMember(dest => dest.YearlyPremium, opt => opt.MapFrom(x => x.YearlyPremium.Amount))
            .ForMember(dest => dest.InsuranceNumber, opt => opt.MapFrom(x => x.InsuranceNumber.Number));
        CreateMap<Insurance, GetInsuranceResponse>()
            .ForMember(dest => dest.YearlyPremium, opt => opt.MapFrom(x => x.YearlyPremium.Amount))
            .ForMember(dest => dest.InsuranceNumber, opt => opt.MapFrom(x => x.InsuranceNumber.Number));
        
        // Insurer
        CreateMap<CreateInsurer, Insurer>()
            .ForMember(dest => dest.OrganizationNumber, opt => opt.Ignore());
        CreateMap<Insurer, InsurerDto>()
            .ForMember(dest => dest.OrganizationNumber, opt => opt.MapFrom(x => x.OrganizationNumber.Number));
        CreateMap<Insurer, GetInsurersResponse>();
        CreateMap<Insurer, CreateInsurerResponse>()
            .ForMember(dest => dest.OrganizationNumber, opt => opt.MapFrom(x => x.OrganizationNumber.Number));

        // Coverage
        CreateMap<CreateInsurerResponse, Insurer>();
        CreateMap<Coverage, CoverageDto>();
    }
};