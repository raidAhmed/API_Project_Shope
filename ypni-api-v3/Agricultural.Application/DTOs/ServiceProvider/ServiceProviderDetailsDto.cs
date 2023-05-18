using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Agricultural.Application.DTOs.SP_Address;
using Agricultural.Application.DTOs.Slider;
using Agricultural.Application.DTOs.SliderImages;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.DTOs.Product;

namespace Agricultural.Application.DTOs.ServiceProvider
{
    public class ServiceProviderDetailsDto
    {
        public ServiceProviderQueryDto ServiceProviderDto { get; set; }
        public List<SP_AddressDto> Sp_AddressList = new List<SP_AddressDto>();
        public List<SP_MainClassificationQueryDto> sP_Mains=new List<SP_MainClassificationQueryDto>();
        public List<SP_AdditionalSectionsQueryDto> SP_Additionals = new List<SP_AdditionalSectionsQueryDto>();
        public List<MainClassificationQueryDto> mainClassf = new List<MainClassificationQueryDto>();
        public List<AdditionalSectionsQueryDto> additionalSections= new List<AdditionalSectionsQueryDto>();
        public List<SpecialSectionsQueryDto> SpecialSections = new List<SpecialSectionsQueryDto>();
        public SliderQueryDto SliderQueryDto { get; set; }
        public List<SliderImagesQueryDto> SliderImagesList = new List<SliderImagesQueryDto>();

        public bool isFafo { get; set; }
        public int EvaluteCount { get; set; }
    }

    public class SPDetailsDto
    {
        public ServiceProviderQueryDto ServiceProvider { get; set; }
        public List<MainClassificationQueryDto> mainClassifications = new List<MainClassificationQueryDto>();
        public List<AdditionalSectionsQueryDto> additionals = new List<AdditionalSectionsQueryDto>();
        public List<SpecialSectionsQueryDto> specialSections = new List<SpecialSectionsQueryDto>();
        public List<productdtoADDapi> productdtoADDapi = new List<productdtoADDapi>();
        public SliderQueryDto SliderQueryDto { get; set; }
        public List<SliderImagesQueryDto> SliderImagesList = new List<SliderImagesQueryDto>();


        public bool isFafo { get; set; }
        public int EvaluteCount { get; set; }
        public int ProductCount { get; set; }

    }
}
