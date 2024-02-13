using InsuranceCoreService.API.Commands;
using InsuranceCoreService.API.Dtos;
using InsuranceCoreService.API.Responses;
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
        CreateMap<CreateInsurerResponse, Insurer>();
        CreateMap<Insurer, CreateInsurerResponse>();
        CreateMap<Insurer, GetInsurersResponse>();

        //CreateMap<Insurer, InsurerDto>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        //    .ForMember(dest => dest.OrganizationNumber, opt => opt.MapFrom(src => src.OrganizationNumber))
        //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<List<Insurer>, GetInsurersResponse>();
    }
};