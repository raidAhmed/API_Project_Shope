using Agricultural.Application.DTOs.ComplainantPic;
using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.DTOs.ServiceProvider;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.ComplainantToParty
{
    public class ComplainantToPartyDDlLViewModels
    {
        public ServiceProviderQueryDto ServiceProviderDtosenderVm { get; set; }
        public ServiceProviderDto ServiceProviderDtoReciverVm { get; set; }
        public List<ComplainantToPartyChatsDto> ComplainantToPartyChatsDto { get; set; }
        public List<ComplainantToPartyQueryDto> ComplainantToPartyQueryDtoVm { get; set; }
        public List<ComplainantToPartyQueryDto> ComplainantToPartyOrderDtoVm { get; set; }
        public ComplainantToPartyDto ComplainantToPartyDto { get; set; }

    }
}
