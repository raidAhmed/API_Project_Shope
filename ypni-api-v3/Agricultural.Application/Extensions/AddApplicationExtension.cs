using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.Services;


using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using AutoMapper.Extensions.ExpressionMapping;


namespace Agricultural.Application.Extensions
{
    public static class AddApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
          services.AddScoped<IServiceManager, ServiceManager>();
            // services.AddScoped<Iservice>
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(cx => { cx.AddExpressionMapping(); }, AppDomain.CurrentDomain.Load("Agricultural.Application"));
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Agricultural.Application"));
            services.AddTransient<IActivityTypeService, ActivityTypeService>();
            services.AddTransient<IAdditionalSectionsService, AdditionalSectionsService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IBusinessCommercialService, BusinessCommercialService>();//t
            services.AddTransient<ICartService, CartService>();//t
            services.AddTransient<ICartDetailsService, CartDetailsService>();//t
            services.AddTransient<ICheckOutService, CheckOutService>();//t
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IComplainantPicService, ComplainantPicService>();//t
            services.AddTransient<IComplainantToPartyService, ComplainantToPartyService>();//t
            services.AddTransient<IConsultationRequestPicService, ConsultationRequestPicService>();//t
            services.AddTransient<IConsultationRequestService, ConsultationRequestService>();//t
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IFarmerService, FarmerService>();//t
            services.AddTransient<IMainClassificationService, MainClassificationService>();
            services.AddTransient<IManufactureCompanyService, ManufactureCompanyService>();//t
            services.AddTransient<IOfferService, OfferService>();//t
            services.AddTransient<IOfficialPartyService, OfficialPartyService>();//t
            services.AddTransient<IOrderService, OrderService>();//t
            services.AddTransient<IOrderDetailsService, OrderDetailsService>();//t
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProduct_AdditionalDetailsService, Product_AdditionalDetailsService>();//t
            services.AddTransient<IProduct_AttributeService, Product_AttributeService>();//t
            services.AddTransient<IProduct_ColorsService, Product_ColorsService>();//tN
            services.AddTransient<IProduct_ImageService, Product_ImageService>();//t
            services.AddTransient<IProduct_UnitService, Product_UnitService>();//t
            services.AddTransient<IProduct_User_FavouritesService, Product_User_FavouritesService>();//t
            services.AddTransient<IProduct_Variant_AttributeService, Product_Variant_AttributeService>();//t
            services.AddTransient<IProduct_variantionService, Product_variantionService>();//t
            services.AddTransient<IProductEvaluatonService, ProductEvaluatonService>();//t
            services.AddTransient<IProFeaturesService, ProFeaturesService>();//tN
            services.AddTransient<IProviderEvaluationService, ProviderEvaluationService>();
            services.AddTransient<IServiceProviderService, ServiceProviderService>();//t
            services.AddTransient<IServicesTypeService, ServicesTypeService>();//tN
            services.AddTransient<ISliderService, SliderService>();//tN
            services.AddTransient<ISliderImagesService, SliderImagesService>();//tN
            services.AddTransient<ISP_AdditionalSectionsService, SP_AdditionalSectionsService>();
            services.AddTransient<ISP_AddressService, SP_AddressService>();
            services.AddTransient<ISP_MainClassificationService, SP_MainClassificationService>();
            services.AddTransient<ISP_ProFeaturesService, SP_ProFeaturesService>();//TN
            services.AddTransient<ISP_User_FavouritesService, SP_User_FavouritesService>();
            services.AddTransient<ISpecialSectionsService, SpecialSectionsService>();
            services.AddTransient<ISupportRequestService, SupportRequestService>();

            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IDirectorateService, DirectorateService>();
            services.AddTransient<IMarketsService, MarketsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWeekdaysService, WeekdaysService>();
            services.AddTransient<IWorkingHoursService, WorkingHoursService>();
            services.AddTransient<IWorkinPoeriodsService, WorkinPoeriodsService>();
            services.AddTransient<IConfigService, ConfigService>();
            services.AddTransient<IBanksService, BanksService>();
            services.AddTransient<IUser_BankService, User_BankService>();

            services.AddTransient(provider =>
                    new Lazy<IActivityTypeService>(provider.GetService<IActivityTypeService>));
            services.AddTransient(provider =>
        new Lazy<IMainClassificationService>(provider.GetService<IMainClassificationService>));
            services.AddTransient(provider =>
        new Lazy<IAdditionalSectionsService>(provider.GetService<IAdditionalSectionsService>));
            services.AddTransient(provider =>    new Lazy<ICityService>(provider.GetService<ICityService>));
            services.AddTransient(provider =>new Lazy<IColorService>(provider.GetService<IColorService>));  
            services.AddTransient(provider =>   new Lazy<IUnitService>(provider.GetService<IUnitService>));  
            services.AddTransient(provider => new Lazy<IUserService>(provider.GetService<IUserService>));   
            services.AddTransient(provider =>new Lazy<IBrandService>(provider.GetService<IBrandService>));
            services.AddTransient(provider =>new Lazy<IManufactureCompanyService>(provider.GetService<IManufactureCompanyService>));
            services.AddScoped(provider => new Lazy<IUploadFileService>(provider.GetService<IUploadFileService>()));
            services.AddTransient(provider =>  new Lazy<IServiceProviderService>(provider.GetService<IServiceProviderService>));
            services.AddTransient(provider =>new Lazy<ICurrencyService>(provider.GetService<ICurrencyService>));    
            services.AddTransient(provider =>new Lazy<IBusinessCommercialService>(provider.GetService<IBusinessCommercialService>));    
            services.AddTransient(provider =>new Lazy<ICartService>(provider.GetService<ICartService>));
            services.AddTransient(provider => new Lazy<ICartDetailsService>(provider.GetService<ICartDetailsService>));
            services.AddTransient(provider =>new Lazy<ICheckOutService>(provider.GetService<ICheckOutService>));    
            services.AddTransient(provider =>new Lazy<IComplainantPicService>(provider.GetService<IComplainantPicService>));    
            services.AddTransient(provider =>new Lazy<IComplainantToPartyService>(provider.GetService<IComplainantToPartyService>));    
            services.AddTransient(provider =>new Lazy<IConsultationRequestPicService>(provider.GetService<IConsultationRequestPicService>));    
            services.AddTransient(provider =>new Lazy<IConsultationRequestService>(provider.GetService<IConsultationRequestService>));    
            services.AddTransient(provider =>new Lazy<IFarmerService>(provider.GetService<IFarmerService>));    
            services.AddTransient(provider =>new Lazy<IOfferService>(provider.GetService<IOfferService>));    
            services.AddTransient(provider =>new Lazy<IOfficialPartyService>(provider.GetService<IOfficialPartyService>));    
            services.AddTransient(provider =>new Lazy<IOrderService>(provider.GetService<IOrderService>));   
            services.AddTransient(provider =>new Lazy<IOrderDetailsService>(provider.GetService<IOrderDetailsService>));    
            services.AddTransient(provider =>new Lazy<IProduct_AdditionalDetailsService>(provider.GetService<IProduct_AdditionalDetailsService>));    
            services.AddTransient(provider =>new Lazy<IProduct_AttributeService>(provider.GetService<IProduct_AttributeService>));    
            services.AddTransient(provider =>new Lazy<IProduct_ImageService>(provider.GetService<IProduct_ImageService>));    
            services.AddTransient(provider =>new Lazy<IProduct_User_FavouritesService>(provider.GetService<IProduct_User_FavouritesService>));    
            services.AddTransient(provider =>new Lazy<IProduct_UnitService>(provider.GetService<IProduct_UnitService>));    
            services.AddTransient(provider =>new Lazy<IProduct_Variant_AttributeService>(provider.GetService<IProduct_Variant_AttributeService>));    
            services.AddTransient(provider =>new Lazy<IProduct_variantionService>(provider.GetService<IProduct_variantionService>));    
            services.AddTransient(provider =>new Lazy<IProductEvaluatonService>(provider.GetService<IProductEvaluatonService>));    
            services.AddTransient(provider =>new Lazy<IProductService>(provider.GetService<IProductService>));    
            services.AddTransient(provider =>new Lazy<IProviderEvaluationService>(provider.GetService<IProviderEvaluationService>));    
            services.AddTransient(provider =>new Lazy<ISP_AdditionalSectionsService>(provider.GetService<ISP_AdditionalSectionsService>));    
            services.AddTransient(provider =>new Lazy<ISP_AddressService>(provider.GetService<ISP_AddressService>));    
            services.AddTransient(provider =>new Lazy<ISP_MainClassificationService>(provider.GetService<ISP_MainClassificationService>));    
            services.AddTransient(provider =>new Lazy<ISP_User_FavouritesService>(provider.GetService<ISP_User_FavouritesService>));    
            services.AddTransient(provider =>new Lazy<ISpecialSectionsService>(provider.GetService<ISpecialSectionsService>));    
            services.AddTransient(provider =>new Lazy<ISupportRequestService>(provider.GetService<ISupportRequestService>));    
            services.AddTransient(provider =>new Lazy<IProductEvaluatonService>(provider.GetService<IProductEvaluatonService>));    
            services.AddTransient(provider =>new Lazy<IProFeaturesService>(provider.GetService<IProFeaturesService>));    
            services.AddTransient(provider =>new Lazy<IProduct_ColorsService>(provider.GetService<IProduct_ColorsService>));    
            services.AddTransient(provider =>new Lazy<IServicesTypeService>(provider.GetService<IServicesTypeService>));    
            services.AddTransient(provider =>new Lazy<ISP_ProFeaturesService>(provider.GetService<ISP_ProFeaturesService>));
            services.AddTransient(provider => new Lazy<ISliderService>(provider.GetService<ISliderService>));
            services.AddTransient(provider => new Lazy<ISliderImagesService>(provider.GetService<ISliderImagesService>));
            services.AddTransient(provider => new Lazy<IRoleService>(provider.GetService<IRoleService>));
            services.AddTransient(provider => new Lazy<IDirectorateService>(provider.GetService<IDirectorateService>));
            services.AddTransient(provider => new Lazy<IMarketsService>(provider.GetService<IMarketsService>));
            services.AddTransient(provider => new Lazy<INewsService>(provider.GetService<INewsService>));
            services.AddTransient(provider => new Lazy<IWeekdaysService>(provider.GetService<IWeekdaysService>));
            services.AddTransient(provider => new Lazy<IWorkingHoursService>(provider.GetService<IWorkingHoursService>));
            services.AddTransient(provider => new Lazy<IWorkinPoeriodsService>(provider.GetService<IWorkinPoeriodsService>));
            services.AddTransient(provider => new Lazy<IConfigService>(provider.GetService<IConfigService>));
            services.AddTransient(provider => new Lazy<IUser_BankService>(provider.GetService<IUser_BankService>));
            services.AddTransient(provider => new Lazy<IBanksService>(provider.GetService<IBanksService>));
            return services;

        }



    }
}
