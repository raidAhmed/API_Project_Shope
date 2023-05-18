using Agricultural.Application.DTOs.BusinessCommercial;
using Agricultural.Application.DTOs.Farmer;
using Agricultural.Application.DTOs.OfficialParty;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.SP_Address;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.ServiceProvider
{
    public class ServiceProviderDDlLViewModels
    {
        public string servicetypeNamebefore { get; set; }
        public ServiceProviderDto ServiceProviderDtoVm { get; set; }
        public SP_AddressDto SP_AddressDtoVm { get; set; }
        public BusinessCommercialDto BusinessCommercialDtoVm { get; set; }
        public OfficialPartyDto OfficialPartyDtoVm { get; set; }
        public FarmerDto FarmerDtoVm { get; set; }

    }
}
