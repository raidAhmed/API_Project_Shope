using Agricultural.Application.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Common
{
    public interface IServiceManager
    {
        IActivityTypeService ActivityTypeService { get; }
        IAdditionalSectionsService AdditionalSectionsService { get; }
        IBrandService BrandService { get; }
        IBusinessCommercialService BusinessCommercialService { get; }
        ICartService CartService { get; }
        ICartDetailsService CartDetailsService { get; }
        ICheckOutService CheckOutService { get; }
        ICityService CityService { get; }
        IColorService ColorService { get; }
        IComplainantPicService ComplainantPicService { get; }
        IComplainantToPartyService ComplainantToPartyService { get; }   
        IConsultationRequestService ConsultationRequestService { get; } 
        IConsultationRequestPicService ConsultationRequestPicService { get; }
        ICurrencyService CurrencyService { get; }
        IFarmerService FarmerService { get; }
        IMainClassificationService MainClassificationService { get; }
        IManufactureCompanyService ManufactureCompanyService { get; }
        IOfferService OfferService { get; }
        IOfficialPartyService OfficialPartyService { get; }

        IOrderService OrderService { get; }
        IOrderDetailsService OrderDetailsService { get; }
        IProductService ProductService { get; }
        IProduct_AdditionalDetailsService Product_AdditionalDetailsService { get; }
        IProduct_AttributeService Product_AttributeService { get; }
        IProduct_ColorsService Product_ColorsService { get; }
        IProduct_ImageService Product_ImageService { get; }
        IProduct_UnitService Product_UnitService { get; }
        IProduct_User_FavouritesService Product_User_FavouritesService { get; }
        IProduct_Variant_AttributeService Product_Variant_AttributeService { get; }
        IProduct_variantionService Product_variantionService { get; }
        IProductEvaluatonService ProductEvaluatonService { get; }
        IProFeaturesService ProFeaturesService { get; }
        IProviderEvaluationService ProviderEvaluationService { get; }
        IServiceProviderService ServiceProviderService { get; }
        IServicesTypeService ServicesTypeService { get; }
        ISliderService SliderService { get; }
        ISliderImagesService SliderImagesService { get; }
        ISP_AdditionalSectionsService SP_AdditionalSectionsService { get; }
        ISP_AddressService SP_AddressService { get; }
        ISP_MainClassificationService SP_MainClassificationService { get; }
        ISP_ProFeaturesService SP_ProFeaturesService { get; }
        ISP_User_FavouritesService SP_User_FavouritesService { get; }
        ISpecialSectionsService SpecialSectionsService { get; }
        ISupportRequestService SupportRequestService { get; }
        IUnitService UnitService { get; }
        IUserService UserService { get; }
        IUploadFileService UploadFileService { get; }
        IRoleService RoleService { get; }
        IDirectorateService DirectorateService { get; }
        IMarketsService MarketsService { get; }
        INewsService NewsService { get; }
        IConfigService ConfigService { get; }
        IWeekdaysService WeekdaysService { get; }
        IWorkingHoursService WorkingHoursService { get; }
        IWorkinPoeriodsService WorkinPoeriodsService { get; }
        IBanksService BanksService { get; }
        IUser_BankService User_BankService { get; } 
    }
}
