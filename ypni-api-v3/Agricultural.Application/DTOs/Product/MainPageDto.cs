using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.SliderImages;
using Agricultural.Application.DTOs.Product;


namespace Agricultural.Application.DTOs.Product
{
    public class MainPageDto
    {
        public List<ActivityTypeQueryDto> activityTypes = new List<ActivityTypeQueryDto>();
        public int? ACtNum { get; set; }
        public List<MainClassificationQueryDto> mainClassifications = new List<MainClassificationQueryDto>();   
        public int? MCNum { get; set; }
        public List<AdditionalSectionsQueryDto> additionalSections = new List<AdditionalSectionsQueryDto>();
        public int? AddSNum { get; set; }
        public List<ServiceProviderQueryDto> serviceProviders = new List<ServiceProviderQueryDto>();
        public List<ServiceProviderDetailsDto> providerDetailsDtos = new List<ServiceProviderDetailsDto>();
        public List<ProductDetailsDto> productDetails = new List<ProductDetailsDto>();
        public List<SliderImagesQueryDto> SliderImages = new List<SliderImagesQueryDto>();
    }
}
