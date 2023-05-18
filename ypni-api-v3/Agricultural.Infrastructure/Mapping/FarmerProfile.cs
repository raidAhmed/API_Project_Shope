using Agricultural.Application.DTOs.Farmer;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class FarmerProfile : Profile
    {
        public FarmerProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<FarmerDto, Agricultural.Domain.Entity.Farmer>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<FarmerQueryDto, Agricultural.Domain.Entity.Farmer>().ReverseMap();
        }
    }
}
