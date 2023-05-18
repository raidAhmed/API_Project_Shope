using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.SP_MainClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.SP_MainClassification
{
    public class SP_MC_VM
    {
        public ServiceProviderQueryDto ServiceProvider { get; set; }
        public List<SP_MainClassificationQueryDto> listSP_MC { get; set; }
        public int Counter { get; set; }

    }
}
