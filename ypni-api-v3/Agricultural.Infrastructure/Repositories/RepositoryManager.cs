using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Repositorys;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        private Lazy<IActivityTypeRepository> _lazyActivityTypeRepository;
        private Lazy<IAdditionalSectionsRepository> _lazyAdditionalSectionsRepository;
        private Lazy<IBrandRepository> _lazyBrandRepository;
        private Lazy<IBusinessCommercialRepository> _lazyBusinessCommercialRepository;
        private Lazy<ICartRepository> _lazyCartRepository;//
        private Lazy<ICartDetailsRepository> _lazyCartDetailsRepository;//
        private Lazy<ICheckOutRepository> _lazyCheckOutRepository;//
        private Lazy<ICityRepository> _lazyCityRepository;
        private Lazy<IColorRepository> _lazyColorRepository;
        private Lazy<IComplainantPicRepository> _lazyComplainantPicRepository;//
        private Lazy<IComplainantToPartyRepository> _lazyComplainantToPartyRepository;//
        private Lazy<IConsultationRequestRepository> _lazyConsultationRequestRepository;//
        private Lazy<IConsultationRequestPicRepository> _lazyConsultationRequestPicRepository;//
        private Lazy<ICurrencyRepository> _lazyCurrencyRepository;
        private Lazy<IFarmerRepository> _lazyFarmerRepository;//
        private Lazy<IMainClassificationRepository> _lazyMainClassificationRepository;
        private Lazy<IManufactureCompanyRepository> _lazyManufactureCompanyRepository;
        private Lazy<IOfferRepository> _lazyOfferRepository;
        private Lazy<IOfficialPartyRepository> _lazyOfficialPartyRepository;
        private Lazy<IOrderRepository> _lazyOrderRepository;
        private Lazy<IOrderDetailsRepository> _lazyOrderDetailsRepository;
        private Lazy<IProductRepository> _lazyProductRepository;
        private Lazy<IProduct_AdditionalDetailsRepository> _lazyProduct_AdditionalDetailsRepository;
        private Lazy<IProduct_AttributeRepository> _lazyProduct_AttributeRepository;
        private Lazy<IProduct_ColorsRepository> _lazyProduct_ColorsRepository;
        private Lazy<IProduct_ImageRepository> _lazyProduct_ImageRepository;
        private Lazy<IProduct_UnitRepository> _lazyProduct_UnitRepository;
        private Lazy<IProduct_User_FavouritesRepository> _lazyProduct_User_FavouritesRepository;
        private Lazy<IProduct_Variant_AttributeRepository> _lazyProduct_Variant_AttributeRepository;
        private Lazy<IProduct_variantionRepository> _lazyProduct_variantionRepository;
        private Lazy<IProductEvaluatonRepository> _lazyProductEvaluatonRepository;
        private Lazy<IProFeaturesRepository> _lazyProFeaturesRepository;
        private Lazy<IProviderEvaluationRepository> _lazyProviderEvaluationRepository;
        private Lazy<IServiceProviderRepository> _lazyServiceProviderRepository;
        private Lazy<IServicesTypeRepository> _lazyServicesTypeRepository;
        private Lazy<ISliderRepository> _lazySliderRepository;
        private Lazy<ISliderImagesRepository> _lazySliderImagesRepository;
        private Lazy<ISP_AdditionalSectionsRepository> _lazySP_AdditionalSectionsRepository;
        private Lazy<ISP_AddressRepository> _lazySP_AddressRepository;
        private Lazy<ISP_MainClassificationRepository> _lazySP_MainClassificationRepository;
        private Lazy<ISP_ProFeaturesRepository> _lazySP_ProFeaturesRepository;
        private Lazy<ISP_User_FavouritesRepository> _lazySP_User_FavouritesRepository;
        private Lazy<ISpecialSectionsRepository> _lazySpecialSectionsRepository;
        private Lazy<ISupportRequestRepository> _lazySupportRequestRepository;
        private Lazy<IUnitRepository> _lazyUnitRepository;
        private Lazy<IDirectorateRepository> _lazyDirectorateRepository;
        private Lazy<IMarketsRepository> _lazyMarketsRepository;
        private Lazy<INewsRepository> _lazyNewsRepository;
        private Lazy<IUserRepository> _lazyUserRepository;
        private Lazy<IUploadFileService> _lazyUploadFileService;
        private Lazy<IWeekdaysRepository> _lazyWeekdaysRepository;
        private Lazy<IWorkinPoeriodsRepository> _lazyWorkinPoeriodsRepository;
        private Lazy<IWorkingHoursRepository> _lazyWorkingHoursRepository;
        private Lazy<IBanksRepository> _lazyBanksRepository;
        private Lazy<IUser_BankRepository> _lazyUser_BankRepository;
        public RepositoryManager(
            Lazy<IUnitOfWork> lazyUnitOfWork,
             Lazy<IActivityTypeRepository> lazyActivityTypeRepository,
            Lazy<IAdditionalSectionsRepository> lazyAdditionalSectionsRepository,
            Lazy<IBrandRepository> lazyBrandRepository,
            Lazy<IBusinessCommercialRepository> lazyBusinessCommercialRepository,
            Lazy<ICartRepository> lazyCartRepository,
            Lazy<ICartDetailsRepository> lazyCartDetailsRepository,
            Lazy<ICheckOutRepository> lazyCheckOutRepository,
            Lazy<ICityRepository> lazyCityRepository,
            Lazy<IColorRepository> lazyColorRepository,
            Lazy<IComplainantPicRepository> lazyComplainantPicRepository,
            Lazy<IComplainantToPartyRepository> lazyComplainantToPartyRepository,
            Lazy<IConsultationRequestRepository> lazyConsultationRequestRepository,
            Lazy<IConsultationRequestPicRepository> lazyConsultationRequestPicRepository,
            Lazy<ICurrencyRepository> lazyCurrencyRepository,
            Lazy<IFarmerRepository> lazyFarmerRepository,
            Lazy<IMainClassificationRepository> lazyMainClassificationRepository,
            Lazy<IManufactureCompanyRepository> lazyManufactureCompanyRepository,
            Lazy<IOfferRepository> lazyOfferRepository,
            Lazy<IOfficialPartyRepository> lazyOfficialPartyRepository,
            Lazy<IOrderRepository> lazyOrderRepository,
            Lazy<IOrderDetailsRepository> lazyOrderDetailsRepository,
            Lazy<IProductRepository> lazyProductRepository,
            Lazy<IProduct_AdditionalDetailsRepository> lazyProduct_AdditionalDetailsRepository,
            Lazy<IProduct_AttributeRepository> lazyProduct_AttributeRepository,
            Lazy<IProduct_ColorsRepository> lazyProduct_ColorsRepository,
            Lazy<IProduct_ImageRepository> lazyProduct_ImageRepository,
            Lazy<IProduct_UnitRepository> lazyProduct_UnitRepository,
            Lazy<IProduct_User_FavouritesRepository> lazyProduct_User_FavouritesRepository,
            Lazy<IProduct_Variant_AttributeRepository> lazyProduct_Variant_AttributeRepository,
            Lazy<IProduct_variantionRepository> lazyProduct_variantionRepository,
            Lazy<IProductEvaluatonRepository> lazyProductEvaluatonRepository,
            Lazy<IProFeaturesRepository> lazyProFeaturesRepository,
            Lazy<IProviderEvaluationRepository> lazyProviderEvaluationRepository,
            Lazy<IServiceProviderRepository> lazyServiceProviderRepository,
            Lazy<IServicesTypeRepository> lazyServicesTypeRepository,
             Lazy<ISliderRepository> lazySliderRepository,
            Lazy<ISliderImagesRepository> lazySliderImagesRepository,
            Lazy<ISP_AdditionalSectionsRepository> lazySP_AdditionalSectionsRepository,
            Lazy<ISP_AddressRepository> lazySP_AddressRepository,
            Lazy<ISP_MainClassificationRepository> lazySP_MainClassificationRepository,
            Lazy<ISP_ProFeaturesRepository> lazySP_ProFeaturesRepository,
            Lazy<ISP_User_FavouritesRepository> lazySP_User_FavouritesRepository,
            Lazy<ISpecialSectionsRepository> lazySpecialSectionsRepository,
            Lazy<ISupportRequestRepository> lazySupportRequestRepository,
            Lazy<IUnitRepository> lazyUnitRepository,
            Lazy<IDirectorateRepository> lazyDirectorateRepository,
            Lazy<IMarketsRepository> lazyMarketsRepository,
            Lazy<INewsRepository> lazyNewsRepository,
            Lazy<IUserRepository> lazyUserRepository,
            Lazy<IWeekdaysRepository> lazyWeekdaysRepository,
            Lazy<IWorkinPoeriodsRepository> lazyWorkinPoeriodsRepository,
            Lazy<IWorkingHoursRepository> lazyWorkingHoursRepository,
            Lazy<IUploadFileService> lazyUploadFileService,
              Lazy<IBanksRepository> lazyBanksRepository,
            Lazy<IUser_BankRepository> lazyUser_BankRepository
            )
        {
            _lazyUnitOfWork = lazyUnitOfWork;
            _lazyActivityTypeRepository = lazyActivityTypeRepository;
            _lazyAdditionalSectionsRepository = lazyAdditionalSectionsRepository;
            _lazyBrandRepository = lazyBrandRepository;
            _lazyBusinessCommercialRepository = lazyBusinessCommercialRepository;
            _lazyCartRepository = lazyCartRepository;
            _lazyCartDetailsRepository = lazyCartDetailsRepository;
            _lazyCheckOutRepository = lazyCheckOutRepository;
            _lazyCityRepository = lazyCityRepository;
            _lazyColorRepository = lazyColorRepository;
            _lazyComplainantPicRepository = lazyComplainantPicRepository;
            _lazyComplainantToPartyRepository = lazyComplainantToPartyRepository;
            _lazyConsultationRequestRepository = lazyConsultationRequestRepository;
            _lazyConsultationRequestPicRepository = lazyConsultationRequestPicRepository;
            _lazyCurrencyRepository = lazyCurrencyRepository;
            _lazyFarmerRepository = lazyFarmerRepository;
            _lazyMainClassificationRepository = lazyMainClassificationRepository;
            _lazyManufactureCompanyRepository = lazyManufactureCompanyRepository;
            _lazyOfferRepository = lazyOfferRepository;
            _lazyOfficialPartyRepository = lazyOfficialPartyRepository;
            _lazyOrderRepository = lazyOrderRepository;
            _lazyOrderDetailsRepository = lazyOrderDetailsRepository;
            _lazyProductRepository = lazyProductRepository;
            _lazyProduct_AdditionalDetailsRepository = lazyProduct_AdditionalDetailsRepository;
            _lazyProduct_AttributeRepository = lazyProduct_AttributeRepository;
            _lazyProduct_ColorsRepository = lazyProduct_ColorsRepository;
            _lazyProduct_ImageRepository = lazyProduct_ImageRepository;
            _lazyProduct_UnitRepository = lazyProduct_UnitRepository;
            _lazyProduct_User_FavouritesRepository = lazyProduct_User_FavouritesRepository;
            _lazyProduct_Variant_AttributeRepository = lazyProduct_Variant_AttributeRepository;
            _lazyProduct_variantionRepository = lazyProduct_variantionRepository;
            _lazyProFeaturesRepository = lazyProFeaturesRepository;
            _lazyProviderEvaluationRepository = lazyProviderEvaluationRepository;
            _lazyServiceProviderRepository = lazyServiceProviderRepository;
            _lazyServicesTypeRepository = lazyServicesTypeRepository;
            _lazySliderRepository = lazySliderRepository;
            _lazySliderImagesRepository = lazySliderImagesRepository;
            _lazySP_AdditionalSectionsRepository = lazySP_AdditionalSectionsRepository;
            _lazySP_AddressRepository = lazySP_AddressRepository;
            _lazySP_MainClassificationRepository = lazySP_MainClassificationRepository;
            _lazySP_ProFeaturesRepository = lazySP_ProFeaturesRepository;
            _lazySP_User_FavouritesRepository = lazySP_User_FavouritesRepository;
            _lazySpecialSectionsRepository = lazySpecialSectionsRepository;
            _lazySupportRequestRepository = lazySupportRequestRepository;
            _lazyUnitRepository = lazyUnitRepository;
            _lazyDirectorateRepository = lazyDirectorateRepository;
            _lazyMarketsRepository = lazyMarketsRepository;
            _lazyNewsRepository = lazyNewsRepository;
            _lazyUserRepository = lazyUserRepository;
            _lazyWeekdaysRepository = lazyWeekdaysRepository;
            _lazyWorkinPoeriodsRepository = lazyWorkinPoeriodsRepository;
            _lazyWorkingHoursRepository = lazyWorkingHoursRepository;
            _lazyUploadFileService = lazyUploadFileService;
            _lazyProductEvaluatonRepository = lazyProductEvaluatonRepository;
            _lazyBanksRepository = lazyBanksRepository;
            _lazyUser_BankRepository = lazyUser_BankRepository;
        }
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IActivityTypeRepository ActivityTypeRepository => _lazyActivityTypeRepository.Value;
        public IAdditionalSectionsRepository AdditionalSectionsRepository => _lazyAdditionalSectionsRepository.Value;
        public IBrandRepository BrandRepository => _lazyBrandRepository.Value;
        public IBusinessCommercialRepository BusinessCommercialRepository => _lazyBusinessCommercialRepository.Value;
        public ICartRepository CartRepository => _lazyCartRepository.Value;
        public ICartDetailsRepository CartDetailsRepository => _lazyCartDetailsRepository.Value;
        public ICheckOutRepository CheckOutRepository => _lazyCheckOutRepository.Value;
        public ICityRepository CityRepository => _lazyCityRepository.Value;
        public IColorRepository ColorRepository => _lazyColorRepository.Value;
        public IComplainantPicRepository ComplainantPicRepository => _lazyComplainantPicRepository.Value;
        public IComplainantToPartyRepository ComplainantToPartyRepository => _lazyComplainantToPartyRepository.Value;
        public IConsultationRequestRepository ConsultationRequestRepository => _lazyConsultationRequestRepository.Value;
        public IConsultationRequestPicRepository ConsultationRequestPicRepository => _lazyConsultationRequestPicRepository.Value;
        public ICurrencyRepository CurrencyRepository => _lazyCurrencyRepository.Value;
        public IFarmerRepository FarmerRepository => _lazyFarmerRepository.Value;
        public IMainClassificationRepository MainClassificationRepository => _lazyMainClassificationRepository.Value;
        public IManufactureCompanyRepository ManufactureCompanyRepository => _lazyManufactureCompanyRepository.Value;
        public IOfferRepository OfferRepository => _lazyOfferRepository.Value;
        public IOfficialPartyRepository OfficialPartyRepository => _lazyOfficialPartyRepository.Value;
        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;
        public IOrderDetailsRepository OrderDetailsRepository => _lazyOrderDetailsRepository.Value;
        public IProductRepository ProductRepository => _lazyProductRepository.Value;
        public IProduct_AdditionalDetailsRepository Product_AdditionalDetailsRepository => _lazyProduct_AdditionalDetailsRepository.Value;

        public IProduct_AttributeRepository Product_AttributeRepository => _lazyProduct_AttributeRepository.Value;

        public IProduct_ColorsRepository Product_ColorsRepository => _lazyProduct_ColorsRepository.Value;

        public IProduct_ImageRepository Product_ImageRepository => _lazyProduct_ImageRepository.Value;

        public IProduct_UnitRepository Product_UnitRepository => _lazyProduct_UnitRepository.Value;

        public IProduct_User_FavouritesRepository Product_User_FavouritesRepository => _lazyProduct_User_FavouritesRepository.Value;

        public IProduct_Variant_AttributeRepository Product_Variant_AttributeRepository => _lazyProduct_Variant_AttributeRepository.Value;

        public IProduct_variantionRepository Product_variantionRepository => _lazyProduct_variantionRepository.Value;

        public IProductEvaluatonRepository ProductEvaluatonRepository => _lazyProductEvaluatonRepository.Value;


        public IProFeaturesRepository ProFeaturesRepository => _lazyProFeaturesRepository.Value;
        public IProviderEvaluationRepository ProviderEvaluationRepository => _lazyProviderEvaluationRepository.Value;
        public IServiceProviderRepository ServiceProviderRepository => _lazyServiceProviderRepository.Value;

        public IServicesTypeRepository ServicesTypeRepository => _lazyServicesTypeRepository.Value;
        public ISP_AdditionalSectionsRepository SP_AdditionalSectionsRepository => _lazySP_AdditionalSectionsRepository.Value;
        public ISP_AddressRepository SP_AddressRepository => _lazySP_AddressRepository.Value;

        public ISP_MainClassificationRepository SP_MainClassificationRepository => _lazySP_MainClassificationRepository.Value;

        public ISP_ProFeaturesRepository SP_ProFeaturesRepository => _lazySP_ProFeaturesRepository.Value;

        public ISP_User_FavouritesRepository SP_User_FavouritesRepository => _lazySP_User_FavouritesRepository.Value;

        public ISpecialSectionsRepository SpecialSectionsRepository => _lazySpecialSectionsRepository.Value;

        public ISupportRequestRepository SupportRequestRepository => _lazySupportRequestRepository.Value;
        public IUnitRepository UnitRepository => _lazyUnitRepository.Value;
        public IDirectorateRepository DirectorateRepository => _lazyDirectorateRepository.Value;
        public IMarketsRepository MarketsRepository => _lazyMarketsRepository.Value;
        public INewsRepository NewsRepository => _lazyNewsRepository.Value;


        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IUploadFileService UploadFileService => _lazyUploadFileService.Value;

        public ISliderRepository SliderRepository => _lazySliderRepository.Value;

        public ISliderImagesRepository SliderImagesRepository => _lazySliderImagesRepository.Value;
        public IWeekdaysRepository WeekdaysRepository => _lazyWeekdaysRepository.Value;
        public IWorkinPoeriodsRepository WorkinPoeriodsRepository => _lazyWorkinPoeriodsRepository.Value;
        public IWorkingHoursRepository WorkingHoursRepository => _lazyWorkingHoursRepository.Value;
        public IBanksRepository BanksRepository => _lazyBanksRepository.Value; 
        public IUser_BankRepository User_BankRepository => _lazyUser_BankRepository.Value;
    }
}
