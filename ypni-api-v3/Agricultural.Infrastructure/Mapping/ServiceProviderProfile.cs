using Agricultural.Application.DTOs.ServiceProvider;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class ServiceProviderProfile : Profile
    {
        public ServiceProviderProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<ServiceProviderDto, Agricultural.Domain.Entity.ServiceProvider>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<ServiceProviderQueryDto, Agricultural.Domain.Entity.ServiceProvider>().ReverseMap();
        }
    }
}
