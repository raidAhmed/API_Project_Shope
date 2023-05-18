using Agricultural.Application.DTOs.User_Bank;

using AutoMapper;



namespace Agricultural.Infrastructure.Mapping
{
    public class User_BankProfile : Profile
    {
        public User_BankProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<User_BankDto, Agricultural.Domain.Entity.User_Bank>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<User_BankQueryDto, Agricultural.Domain.Entity.User_Bank>().ReverseMap();
        }
    }
}
