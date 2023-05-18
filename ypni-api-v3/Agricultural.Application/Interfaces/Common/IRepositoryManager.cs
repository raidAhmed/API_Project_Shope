using Agricultural.Application.Interfaces.Repositorys;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Common
{
    public interface IRepositoryManager
    {
        IActivityTypeRepository ActivityTypeRepository { get; }
        IAdditionalSectionsRepository AdditionalSectionsRepository { get; }
        IBrandRepository BrandRepository { get; }
        IBusinessCommercialRepository BusinessCommercialRepository { get; }
        ICartRepository CartRepository { get; }
        ICartDetailsRepository CartDetailsRepository { get; }
        ICheckOutRepository CheckOutRepository { get; }
        ICityRepository CityRepository { get; }
        IColorRepository ColorRepository { get; }
        IComplainantPicRepository ComplainantPicRepository { get; }
        IComplainantToPartyRepository ComplainantToPartyRepository { get; }
        IConsultationRequestPicRepository ConsultationRequestPicRepository { get; }
        IConsultationRequestRepository ConsultationRequestRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IFarmerRepository FarmerRepository { get; }
        IMainClassificationRepository MainClassificationRepository { get; }
        IManufactureCompanyRepository ManufactureCompanyRepository { get; }
        IOfferRepository OfferRepository { get; }
        IOfficialPartyRepository OfficialPartyRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IProductRepository ProductRepository { get; }
        IProduct_AdditionalDetailsRepository Product_AdditionalDetailsRepository { get; }
        IProduct_AttributeRepository Product_AttributeRepository { get; }
        IProduct_ColorsRepository Product_ColorsRepository { get; }
        IProduct_ImageRepository Product_ImageRepository { get; }
        IProduct_UnitRepository Product_UnitRepository { get; }
        IProduct_User_FavouritesRepository Product_User_FavouritesRepository { get; }
        IProduct_Variant_AttributeRepository Product_Variant_AttributeRepository { get; }
        IProduct_variantionRepository Product_variantionRepository { get; }
        IProductEvaluatonRepository ProductEvaluatonRepository { get; }
        IProFeaturesRepository ProFeaturesRepository { get; }

        IProviderEvaluationRepository ProviderEvaluationRepository { get; }
        IServiceProviderRepository ServiceProviderRepository { get; }
        IServicesTypeRepository ServicesTypeRepository { get; }
        ISliderRepository SliderRepository { get; }
        ISliderImagesRepository SliderImagesRepository { get; }
        ISP_AdditionalSectionsRepository SP_AdditionalSectionsRepository { get; }
        ISP_AddressRepository SP_AddressRepository { get; }
        ISP_MainClassificationRepository SP_MainClassificationRepository { get; }
        ISP_ProFeaturesRepository SP_ProFeaturesRepository { get; }
        ISP_User_FavouritesRepository SP_User_FavouritesRepository { get; }
        ISpecialSectionsRepository SpecialSectionsRepository { get; }
        ISupportRequestRepository SupportRequestRepository { get; }
        IUnitRepository UnitRepository { get; }
        IUserRepository UserRepository { get; }
        IDirectorateRepository DirectorateRepository { get; }
        IMarketsRepository MarketsRepository { get; }
        INewsRepository NewsRepository { get; }
        IUnitOfWork UnitOfWork { get; }
        IWeekdaysRepository WeekdaysRepository { get; }
        IWorkinPoeriodsRepository WorkinPoeriodsRepository { get; }
        IWorkingHoursRepository WorkingHoursRepository { get; }
        IBanksRepository BanksRepository { get; }
        IUser_BankRepository User_BankRepository { get; } 

    }
}
