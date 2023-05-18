using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.Brand;
using Agricultural.Application.DTOs.SliderImages;

namespace Agricultural.Application.DTOs.Product
{
    public class ViewProductsDto
    {
       public ProductQueryDto product { get; set; }
        public List<ProductQueryDto> Listproduct =new List<ProductQueryDto>();
        public List<ProductDetailsDto> ProductDetails =new List<ProductDetailsDto>();
        public ActivityTypeQueryDto activityType { get; set; }
        public List<MainClassificationQueryDto> mains =new List<MainClassificationQueryDto>();  
        public List<AdditionalSectionsQueryDto> additional= new List<AdditionalSectionsQueryDto>();
        public List<SpecialSectionsQueryDto> specialSec=new List<SpecialSectionsQueryDto>();
        
        public List<ColorQueryDto> colors =new List<ColorQueryDto>();

        public ServiceProviderQueryDto serviceProvider { get; set; }

        // Count of Products
        public int AllProduct { get; set; }
        public int CurentProduct { get; set; }
    }

    public class ViewHomeDto
    {
        public List<ServiceProviderQueryDto> serviceProvider = new List<ServiceProviderQueryDto>();
        public List<productdtoADDapi> productdtoADDapis = new List<productdtoADDapi>();
        public List<MainClassificationQueryDto> MainClass= new List<MainClassificationQueryDto>();
        public List<AdditionalSectionsQueryDto> AdditionSec = new List<AdditionalSectionsQueryDto>();
        public List<ActivityTypeQueryDto> activityTypes= new List<ActivityTypeQueryDto>();  
        public List<BrandQueryDto> Brands= new List<BrandQueryDto>();
        public List<ColorQueryDto> Colors = new List<ColorQueryDto>();
        public List<SliderImagesQueryDto> SliderImages = new List<SliderImagesQueryDto>();
    }
}
