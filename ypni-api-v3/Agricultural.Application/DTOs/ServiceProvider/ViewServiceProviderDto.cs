using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Agricultural.Application.DTOs.SpecialSections;


namespace Agricultural.Application.DTOs.ServiceProvider
{
    public class ViewServiceProviderDto
    {
        public List<ServiceProviderQueryDto> servicesProvider = new List<ServiceProviderQueryDto>();
        public List<MainClassificationQueryDto> mainClassifications = new List<MainClassificationQueryDto>();   
        public List<AdditionalSectionsQueryDto> additionalSections = new List<AdditionalSectionsQueryDto>();    
        public List<SpecialSectionsQueryDto> specialSections= new List<SpecialSectionsQueryDto>();
        public List<SP_MainClassificationQueryDto> sP_Mains = new List<SP_MainClassificationQueryDto>();
        public List<SP_AdditionalSectionsQueryDto> sP_Additionals= new List<SP_AdditionalSectionsQueryDto>();

        // All Data for Service Provider
        public List<ServiceProviderDetailsDto> serviceProvidersDetails = new List<ServiceProviderDetailsDto>();
       

    }
}
