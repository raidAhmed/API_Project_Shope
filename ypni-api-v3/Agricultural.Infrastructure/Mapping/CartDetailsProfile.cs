using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.DTOs.CartDetails;

using AutoMapper;


namespace Agricultural.Infrastructure.Mapping
{
    public class CartDetailsProfile : Profile
    {
        public CartDetailsProfile()
        {
            //Mapping CreateDto To Entity
            CreateMap<CartDetailsDto, Agricultural.Domain.Entity.CartDetails>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<CartDetailsQueryDto, Agricultural.Domain.Entity.CartDetails>().ReverseMap();
        }
    }
}
