using Agricultural.Application.DTOs.ManufactureCompany;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ManufactureCompanyProfile : Profile
    {
        public ManufactureCompanyProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ManufactureCompanyDto, Agricultural.Domain.Entity.ManufactureCompany>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ManufactureCompanyQueryDto, Agricultural.Domain.Entity.ManufactureCompany>().ReverseMap();
        }
    }
}
