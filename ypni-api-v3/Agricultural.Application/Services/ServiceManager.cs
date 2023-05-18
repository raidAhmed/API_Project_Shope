using Agricultural.Application.Interfaces.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Services
{
    internal class ServiceManager : IServiceManager
    {
        private Lazy<IActivityTypeService> _lazyActivityTypeService;
        private Lazy<IAdditionalSectionsService> _lazyAdditionalSectionsService;
        private Lazy<IBrandService> _lazyBrandService;
        private Lazy<IBusinessCommercialService> _lazyBusinessCommercialService;
        private Lazy<ICartService> _lazyCartService;//
        private Lazy<ICartDetailsService> _lazyCartDetailsService;//
        private Lazy<ICheckOutService> _lazyCheckOutService;//
        private Lazy<ICityService> _lazyCityService;
        private Lazy<IColorService> _lazyColorService;
        private Lazy<IComplainantPicService> _lazyComplainantPicService;//
        private Lazy<IComplainantToPartyService> _lazyComplainantToPartyService;//
        private Lazy<IConsultationRequestService> _lazyConsultationRequestService;//
        private Lazy<IConsultationRequestPicService> _lazyConsultationRequestPicService;//
        private Lazy<ICurrencyService> _lazyCurrencyService;
        private Lazy<IFarmerService> _lazyFarmerService;//
        private Lazy<IMainClassificationService> _lazyMainClassificationService;
        private Lazy<IManufactureCompanyService> _lazyManufactureCompanyService;
        private Lazy<IOfferService> _lazyOfferService;
        private Lazy<IOfficialPartyService> _lazyOfficialPartyService;
        private Lazy<IOrderService> _lazyOrderService;
        private Lazy<IOrderDetailsService> _lazyOrderDetailsService;
        private Lazy<IProductService> _lazyProductService;
        private Lazy<IProduct_AdditionalDetailsService> _lazyProduct_AdditionalDetailsService;
        private Lazy<IProduct_AttributeService> _lazyProduct_AttributeService;
        private Lazy<IProduct_ColorsService> _lazyProduct_ColorsService;
        private Lazy<IProduct_ImageService> _lazyProduct_ImageService;
        private Lazy<IProduct_UnitService> _lazyProduct_UnitService;
        private Lazy<IProduct_User_FavouritesService> _lazyProduct_User_FavouritesService;
        private Lazy<IProduct_Variant_AttributeService> _lazyProduct_Variant_AttributeService;
        private Lazy<IProduct_variantionService> _lazyProduct_variantionService;
        private Lazy<IProductEvaluatonService> _lazyProductEvaluatonService;
        private Lazy<IProFeaturesService> _lazyProFeaturesService;
        private Lazy<IProviderEvaluationService> _lazyProviderEvaluationService;
        private Lazy<IServiceProviderService> _lazyServiceProviderService;
        private Lazy<IServicesTypeService> _lazyServicesTypeService;
        private Lazy<ISliderService> _lazySliderService;
        private Lazy<ISliderImagesService> _lazySliderImagesService;
        private Lazy<ISP_AdditionalSectionsService> _lazySP_AdditionalSectionsService;
        private Lazy<ISP_AddressService> _lazySP_AddressService;
        private Lazy<ISP_MainClassificationService> _lazySP_MainClassificationService;
        private Lazy<ISP_ProFeaturesService> _lazySP_ProFeaturesService;
        private Lazy<ISP_User_FavouritesService> _lazySP_User_FavouritesService;
        private Lazy<ISpecialSectionsService> _lazySpecialSectionsService;
        private Lazy<ISupportRequestService> _lazySupportRequestService;
        private Lazy<IUnitService> _lazyUnitService;
        private Lazy<IUserService> _lazyUserService;
        private Lazy<IUploadFileService> _lazyUploadFileService;
        private Lazy<IRoleService> _lazyRoleService;
        private Lazy<IDirectorateService> _lazyDirectorateService;
        private Lazy<IMarketsService> _lazyMarketsService;
        private Lazy<INewsService> _lazyNewsService;
        private Lazy<IWeekdaysService> _lazyWeekdaysService;
        private Lazy<IWorkingHoursService> _lazyWorkingHoursService;
        private Lazy<IWorkinPoeriodsService> _lazyWorkinPoeriodsService;
        private Lazy<IConfigService> _lazyConfigService;
        private Lazy<IBanksService> _lazyBanksService;
        private Lazy<IUser_BankService> _lazyUser_BankService;
        
        public ServiceManager(Lazy<IRoleService> lazyRoleService,
            Lazy<IActivityTypeService> lazyActivityTypeService,
            Lazy<IAdditionalSectionsService> lazyAdditionalSectionsService,
            Lazy<IBrandService> lazyBrandService,
            Lazy<IBusinessCommercialService> lazyBusinessCommercialService,
            Lazy<ICartService> lazyCartService,
            Lazy<ICartDetailsService> lazyCartDetailsService,
            Lazy<ICheckOutService> lazyCheckOutService,
            Lazy<ICityService> lazyCityService,
            Lazy<IColorService> lazyColorService,
            Lazy<IComplainantPicService> lazyComplainantPicService,
            Lazy<IComplainantToPartyService> lazyComplainantToPartyService,
            Lazy<IConsultationRequestService> lazyConsultationRequestService,
            Lazy<IConsultationRequestPicService> lazyConsultationRequestPicService,
            Lazy<ICurrencyService> lazyCurrencyService,
            Lazy<IFarmerService> lazyFarmerService,
            Lazy<IMainClassificationService> lazyMainClassificationService,
            Lazy<IManufactureCompanyService> lazyManufactureCompanyService,
            Lazy<IOfferService> lazyOfferService,
            Lazy<IOfficialPartyService> lazyOfficialPartyService,
            Lazy<IOrderService> lazyOrderService,
            Lazy<IOrderDetailsService> lazyOrderDetailsService,
            Lazy<IProductService> lazyProductService,
            Lazy<IProduct_AdditionalDetailsService> lazyProduct_AdditionalDetailsService,
            Lazy<IProduct_AttributeService> lazyProduct_AttributeService,
            Lazy<IProduct_ColorsService> lazyProduct_ColorsService,
            Lazy<IProduct_ImageService> lazyProduct_ImageService,
            Lazy<IProduct_UnitService> lazyProduct_UnitService,
            Lazy<IProduct_User_FavouritesService> lazyProduct_User_FavouritesService,
            Lazy<IProduct_Variant_AttributeService> lazyProduct_Variant_AttributeService,
            Lazy<IProduct_variantionService> lazyProduct_variantionService,
            Lazy<IProductEvaluatonService> lazyProductEvaluatonService,
            Lazy<IProFeaturesService> lazyProFeaturesService,
            Lazy<IProviderEvaluationService> lazyProviderEvaluationService,
            Lazy<IServiceProviderService> lazyServiceProviderService,
            Lazy<IServicesTypeService> lazyServicesTypeService,
             Lazy<ISliderService> lazySliderService,
            Lazy<ISliderImagesService> lazySliderImagesService,
            Lazy<ISP_AdditionalSectionsService> lazySP_AdditionalSectionsService,
            Lazy<ISP_AddressService> lazySP_AddressService,
            Lazy<ISP_MainClassificationService> lazySP_MainClassificationService,
            Lazy<ISP_ProFeaturesService> lazySP_ProFeaturesService,
            Lazy<ISP_User_FavouritesService> lazySP_User_FavouritesService,
            Lazy<ISpecialSectionsService> lazySpecialSectionsService,
            Lazy<ISupportRequestService> lazySupportRequestService,
            Lazy<IUnitService> lazyUnitService,
            Lazy<IUserService> lazyUserService,
            Lazy<IUploadFileService> lazyUploadFileService,
            Lazy<IDirectorateService> lazyDirectorateService,
            Lazy<IMarketsService> lazyMarketsService,
            Lazy<INewsService> lazyNewsService,
            Lazy<IWeekdaysService> lazyWeekdaysService,
            Lazy<IWorkingHoursService> lazyWorkingHoursService,
            Lazy<IWorkinPoeriodsService> lazyWorkinPoeriodsService,
            Lazy<IConfigService> lazyConfigService,
            Lazy<IBanksService> lazyBanksService,
            Lazy<IUser_BankService> lazyUser_BankService

            )
        {
            _lazyActivityTypeService = lazyActivityTypeService;
            _lazyAdditionalSectionsService = lazyAdditionalSectionsService;
            _lazyBrandService = lazyBrandService;
            _lazyBusinessCommercialService= lazyBusinessCommercialService;
            _lazyCartService = lazyCartService;
            _lazyCartDetailsService = lazyCartDetailsService;
            _lazyCheckOutService = lazyCheckOutService;
            _lazyCityService = lazyCityService;
            _lazyColorService = lazyColorService;
            _lazyComplainantPicService = lazyComplainantPicService;
            _lazyComplainantToPartyService = lazyComplainantToPartyService;
            _lazyConsultationRequestService = lazyConsultationRequestService;
            _lazyConsultationRequestPicService = lazyConsultationRequestPicService;
            _lazyCurrencyService = lazyCurrencyService;
            _lazyFarmerService = lazyFarmerService;
            _lazyMainClassificationService = lazyMainClassificationService;
            _lazyManufactureCompanyService = lazyManufactureCompanyService;
            _lazyOfferService = lazyOfferService;
            _lazyOfficialPartyService= lazyOfficialPartyService;
            _lazyOrderService = lazyOrderService;
            _lazyOrderDetailsService = lazyOrderDetailsService;
            _lazyProductService = lazyProductService;
            _lazyProduct_AdditionalDetailsService = lazyProduct_AdditionalDetailsService;
            _lazyProduct_AttributeService = lazyProduct_AttributeService;
            _lazyProduct_ColorsService = lazyProduct_ColorsService;
            _lazyProduct_ImageService= lazyProduct_ImageService;
            _lazyProduct_UnitService= lazyProduct_UnitService;
            _lazyProduct_User_FavouritesService= lazyProduct_User_FavouritesService;
            _lazyProduct_Variant_AttributeService = lazyProduct_Variant_AttributeService;
            _lazyProduct_variantionService = lazyProduct_variantionService;
            _lazyProFeaturesService = lazyProFeaturesService;
            _lazyProviderEvaluationService = lazyProviderEvaluationService;
            _lazyServiceProviderService = lazyServiceProviderService;
            _lazyServicesTypeService = lazyServicesTypeService;
            _lazySliderService = lazySliderService;
            _lazySliderImagesService = lazySliderImagesService;
            _lazySP_AdditionalSectionsService = lazySP_AdditionalSectionsService;
            _lazySP_AddressService = lazySP_AddressService;
            _lazySP_MainClassificationService = lazySP_MainClassificationService;
            _lazySP_ProFeaturesService = lazySP_ProFeaturesService;
            _lazySP_User_FavouritesService=lazySP_User_FavouritesService;
            _lazySpecialSectionsService = lazySpecialSectionsService;
            _lazySupportRequestService = lazySupportRequestService;
            _lazyUnitService = lazyUnitService;
            _lazyUserService = lazyUserService;
            _lazyUploadFileService = lazyUploadFileService;
            _lazyRoleService = lazyRoleService;
            _lazyDirectorateService = lazyDirectorateService;
            _lazyMarketsService = lazyMarketsService;
            _lazyNewsService = lazyNewsService;
            _lazyWeekdaysService = lazyWeekdaysService;
            _lazyWorkingHoursService = lazyWorkingHoursService;
            _lazyWorkinPoeriodsService = lazyWorkinPoeriodsService;
            _lazyProductEvaluatonService=lazyProductEvaluatonService;
            _lazyConfigService = lazyConfigService;
            _lazyBanksService = lazyBanksService;
            _lazyUser_BankService = lazyUser_BankService;

        }
        public IActivityTypeService ActivityTypeService => _lazyActivityTypeService.Value;
        public IAdditionalSectionsService AdditionalSectionsService => _lazyAdditionalSectionsService.Value;
        public IBrandService BrandService => _lazyBrandService.Value;
        public IBusinessCommercialService BusinessCommercialService => _lazyBusinessCommercialService.Value;
        public ICartService CartService => _lazyCartService.Value;
        public ICartDetailsService CartDetailsService => _lazyCartDetailsService.Value;
        public ICheckOutService CheckOutService => _lazyCheckOutService.Value;
        public ICityService CityService => _lazyCityService.Value;
        public IColorService ColorService => _lazyColorService.Value;
        public IComplainantPicService ComplainantPicService => _lazyComplainantPicService.Value;
        public IComplainantToPartyService ComplainantToPartyService => _lazyComplainantToPartyService.Value;
        public IConsultationRequestService ConsultationRequestService => _lazyConsultationRequestService.Value;
        public IConsultationRequestPicService ConsultationRequestPicService => _lazyConsultationRequestPicService.Value;
        public ICurrencyService CurrencyService => _lazyCurrencyService.Value;
        public IFarmerService FarmerService => _lazyFarmerService.Value;
        public IMainClassificationService MainClassificationService => _lazyMainClassificationService.Value;
        public IManufactureCompanyService ManufactureCompanyService => _lazyManufactureCompanyService.Value;
        public IOfferService OfferService => _lazyOfferService.Value;
        public IOfficialPartyService OfficialPartyService => _lazyOfficialPartyService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IOrderDetailsService OrderDetailsService => _lazyOrderDetailsService.Value;
        public IProductService ProductService => _lazyProductService.Value;
        public IProduct_AdditionalDetailsService Product_AdditionalDetailsService => _lazyProduct_AdditionalDetailsService.Value;

        public IProduct_AttributeService Product_AttributeService => _lazyProduct_AttributeService.Value;

        public IProduct_ColorsService Product_ColorsService => _lazyProduct_ColorsService.Value;

        public IProduct_ImageService Product_ImageService => _lazyProduct_ImageService.Value;

        public IProduct_UnitService Product_UnitService => _lazyProduct_UnitService.Value;

        public IProduct_User_FavouritesService Product_User_FavouritesService => _lazyProduct_User_FavouritesService.Value;

        public IProduct_Variant_AttributeService Product_Variant_AttributeService => _lazyProduct_Variant_AttributeService.Value;

        public IProduct_variantionService Product_variantionService => _lazyProduct_variantionService.Value;

        public IProductEvaluatonService ProductEvaluatonService => _lazyProductEvaluatonService.Value;


        public IProFeaturesService ProFeaturesService => _lazyProFeaturesService.Value;
        public IProviderEvaluationService ProviderEvaluationService => _lazyProviderEvaluationService.Value;
        public IServiceProviderService ServiceProviderService => _lazyServiceProviderService.Value;

        public IServicesTypeService ServicesTypeService => _lazyServicesTypeService.Value;
        public ISliderService SliderService => _lazySliderService.Value;
        public ISliderImagesService SliderImagesService => _lazySliderImagesService.Value;
        public ISP_AdditionalSectionsService SP_AdditionalSectionsService => _lazySP_AdditionalSectionsService.Value;
        public ISP_AddressService SP_AddressService => _lazySP_AddressService.Value;

        public ISP_MainClassificationService SP_MainClassificationService => _lazySP_MainClassificationService.Value;

        public ISP_ProFeaturesService SP_ProFeaturesService => _lazySP_ProFeaturesService.Value;

        public ISP_User_FavouritesService SP_User_FavouritesService => _lazySP_User_FavouritesService.Value;

        public ISpecialSectionsService SpecialSectionsService => _lazySpecialSectionsService.Value;

        public ISupportRequestService SupportRequestService => _lazySupportRequestService.Value;
        public IUnitService UnitService => _lazyUnitService.Value;


        public IUserService UserService => _lazyUserService.Value;
        public IRoleService RoleService => _lazyRoleService.Value;
        public IDirectorateService DirectorateService => _lazyDirectorateService.Value;
        public IMarketsService MarketsService => _lazyMarketsService.Value;
        public INewsService NewsService => _lazyNewsService.Value;
        public IWeekdaysService WeekdaysService => _lazyWeekdaysService.Value;
        public IWorkingHoursService WorkingHoursService => _lazyWorkingHoursService.Value;
        public IWorkinPoeriodsService WorkinPoeriodsService => _lazyWorkinPoeriodsService.Value;
        public IConfigService ConfigService => _lazyConfigService.Value;
        public IUploadFileService UploadFileService => _lazyUploadFileService.Value;
        public IBanksService BanksService => _lazyBanksService.Value;
        public IUser_BankService User_BankService => _lazyUser_BankService.Value;


    }
}
