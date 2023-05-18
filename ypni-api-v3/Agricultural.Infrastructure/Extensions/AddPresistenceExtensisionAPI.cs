using Agricultural.Infrastructure.DbContexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Infrastructure.Repositories;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.Services;
using Agricultural.Infrastructure.Oauth;

namespace Agricultural.Infrastructure.Extensions
{
    public static class AddPresistenceExtensisionAPI
    {
        public static IServiceCollection AddPresistenceAPI(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddScoped<Iservice>

            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<User>(bulder =>
            {
                bulder.User.RequireUniqueEmail = false;



                bulder.Password.RequireLowercase = false;
                bulder.Password.RequireDigit = false;
                bulder.Password.RequiredUniqueChars = 0;
                bulder.Password.RequireUppercase = false;
                bulder.Password.RequireNonAlphanumeric = false;
                bulder.Password.RequiredLength = 6;
            }).AddSignInManager().AddRoles<IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            var jwtConfig = configuration.GetSection("JwtSettings");
            var secretKey = jwtConfig["Secret"];
            var tokenValidateParameter = new TokenValidationParameters
            {
                 
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig["validIssuer"],
                ValidAudience = jwtConfig["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            services.AddSingleton(tokenValidateParameter);
            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                // op.Authority = ;
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                //  op.Authority = jwtSettings.Issure;
                //op.RequireHttpsMetadata = false;
                op.TokenValidationParameters = tokenValidateParameter;

            });
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(IdentityConstants.ApplicationScheme);


            services.TryAddSingleton<ISystemClock, SystemClock>();



            services.AddScoped<ISignInManager, SigninManager>();
            services.AddTransient<IRolesManager, RoleManagerImp>();
            services.AddTransient<IJwtTokenManager, JwtTokenManager>();
            //services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddTransient<IUserManager, UserManagerImpl>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IActivityTypeRepository, ActivityTypeRepository>();//f
            services.AddTransient<IAdditionalSectionsRepository, AdditionalSectionsRepository>();//f
            services.AddTransient<IBrandRepository, BrandRepository>();//f
            services.AddTransient<IBusinessCommercialRepository, BusinessCommercialRepository>();//t
            services.AddTransient<ICartRepository, CartRepository>();//t
            services.AddTransient<ICartDetailsRepository, CartDetailsRepository>();//t
            services.AddTransient<ICheckOutRepository, CheckOutRepository>();//t
            services.AddTransient<ICityRepository, CityRepository>();//f
            services.AddTransient<IColorRepository, ColorRepository>();//f
            services.AddTransient<IComplainantToPartyRepository, ComplainantToPartyRepository>();//t
            services.AddTransient<IComplainantPicRepository, ComplainantPicRepository>();//t
            services.AddTransient<IConsultationRequestRepository, ConsultationRequestRepository>();//t
            services.AddTransient<IConsultationRequestPicRepository, ConsultationRequestPicRepository>();//t
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();//f
            services.AddTransient<IFarmerRepository, FarmerRepository>();//t
            services.AddTransient<IMainClassificationRepository, MainClassificationRepository>();//f
            services.AddTransient<IManufactureCompanyRepository, ManufactureCompanyRepository>();//f
            services.AddTransient<IOfferRepository, OfferRepository>();//t
            services.AddTransient<IOfficialPartyRepository, OfficialPartyRepository>();//t
            services.AddTransient<IOrderRepository, OrderRepository>();//t
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();//t
            services.AddTransient<IProductRepository, ProductRepository>();//t
            services.AddTransient<IProduct_AdditionalDetailsRepository, Product_AdditionalDetailsRepository>();//t
            services.AddTransient<IProduct_AttributeRepository, Product_AttributeRepository>();//t
            services.AddTransient<IProduct_ColorsRepository, Product_ColorsRepository>();//t
            services.AddTransient<IProduct_ImageRepository, Product_ImageRepository>();//t
            // unitSize
            services.AddTransient<IProduct_UnitRepository, Product_UnitRepository>();//t
            services.AddTransient<IProduct_User_FavouritesRepository, Product_User_FavouritesRepository>();//t
            services.AddTransient<IProduct_Variant_AttributeRepository, Product_Variant_AttributeRepository>();//t
            services.AddTransient<IProduct_variantionRepository, Product_variantionRepository>();//tn
            services.AddTransient<IProductEvaluatonRepository, ProductEvaluatonRepository>();//t
            services.AddTransient<IProFeaturesRepository, ProFeaturesRepository>();//tn
            services.AddTransient<IProviderEvaluationRepository, ProviderEvaluationRepository>();//fn
            services.AddTransient<IServiceProviderRepository, ServiceProviderRepository>();//f
            services.AddTransient<IServicesTypeRepository, ServiceTypeRepository>();//fn
            services.AddTransient<ISliderRepository, SliderRepository>();//fn
            services.AddTransient<ISliderImagesRepository, SliderImagesRepository>();//fn
            services.AddTransient<ISP_AdditionalSectionsRepository, SP_AdditionalSectionsRepository>();//fn
            services.AddTransient<ISP_AddressRepository, SP_AddressRepository>();//fn
            services.AddTransient<ISP_MainClassificationRepository, SP_MainClassificationRepository>();//fn
            services.AddTransient<ISP_ProFeaturesRepository, SP_ProFeaturesRepository>();//fn
            services.AddTransient<ISP_User_FavouritesRepository, SP_User_FavouritesRepository>();//fn

            services.AddTransient<ISpecialSectionsRepository, SpecialSectionsRepository>();//fn
            services.AddTransient<ISupportRequestRepository, SupportRequestRepository>();//fn


            services.AddTransient<IUnitRepository, UnitRepository>();//f
            services.AddTransient<IDirectorateRepository, DirectorateRepository>();//f
            services.AddTransient<IMarketsRepository, MarketsRepository>();//f
            services.AddTransient<INewsRepository, NewsRepository>();//f

            services.AddTransient<IUserRepository, UserRepository>();//f

            services.AddTransient<IUploadFileService, UploadFileService>();
            services.AddTransient<ICustomConventer, CustomConventer>();

            services.AddTransient<IWorkingHoursRepository, WorkingHoursRepository>();
            services.AddTransient<IWeekdaysRepository, WeekdaysRepository>();
            services.AddTransient<IWorkinPoeriodsRepository, WorkinPoeriodsRepository>();
            services.AddTransient<IBanksRepository, BanksRepository>();
            services.AddTransient<IUser_BankRepository, User_BankRepository>();
            /// INJECT LAZY
            services.AddTransient(provider =>
                  new Lazy<IUnitOfWork>(provider.GetService<IUnitOfWork>));


            services.AddTransient(provider =>
                    new Lazy<IActivityTypeRepository>(provider.GetService<IActivityTypeRepository>));

            services.AddTransient(provider =>
                    new Lazy<IAdditionalSectionsRepository>(provider.GetService<IAdditionalSectionsRepository>));
            services.AddTransient(provider =>
                    new Lazy<IBusinessCommercialRepository>(provider.GetService<IBusinessCommercialRepository>));
            services.AddTransient(provider =>
                    new Lazy<ICartRepository>(provider.GetService<ICartRepository>));
            services.AddTransient(provider =>
                    new Lazy<ICartDetailsRepository>(provider.GetService<ICartDetailsRepository>));
            services.AddTransient(provider =>
                    new Lazy<ICheckOutRepository>(provider.GetService<ICheckOutRepository>));
            services.AddTransient(provider =>
                    new Lazy<IComplainantToPartyRepository>(provider.GetService<IComplainantToPartyRepository>));

            services.AddTransient(provider =>
                    new Lazy<IComplainantPicRepository>(provider.GetService<IComplainantPicRepository>));
            services.AddTransient(provider =>
                    new Lazy<IConsultationRequestRepository>(provider.GetService<IConsultationRequestRepository>));
            services.AddTransient(provider =>
                    new Lazy<IConsultationRequestPicRepository>(provider.GetService<IConsultationRequestPicRepository>));



            services.AddTransient(provider =>
                    new Lazy<IMainClassificationRepository>(provider.GetService<IMainClassificationRepository>));

            services.AddTransient(provider =>
                    new Lazy<IColorRepository>(provider.GetService<IColorRepository>));

            services.AddTransient(provider =>
                     new Lazy<ICityRepository>(provider.GetService<ICityRepository>));

            services.AddTransient(provider =>
                    new Lazy<IUnitRepository>(provider.GetService<IUnitRepository>));
            services.AddTransient(provider =>
                    new Lazy<IUserRepository>(provider.GetService<IUserRepository>));
            services.AddTransient(provider =>
                    new Lazy<IBrandRepository>(provider.GetService<IBrandRepository>));
            services.AddTransient(provider =>
                    new Lazy<IManufactureCompanyRepository>(provider.GetService<IManufactureCompanyRepository>));
            services.AddTransient(provider =>
                   new Lazy<IServiceProviderRepository>(provider.GetService<IServiceProviderRepository>));
            services.AddTransient(provider =>
                   new Lazy<ICurrencyRepository>(provider.GetService<ICurrencyRepository>));
            services.AddTransient(provider =>
                    new Lazy<IOfferRepository>(provider.GetService<IOfferRepository>));
            services.AddTransient(provider =>
                    new Lazy<IFarmerRepository>(provider.GetService<IFarmerRepository>));
            services.AddTransient(provider =>
                    new Lazy<IOfficialPartyRepository>(provider.GetService<IOfficialPartyRepository>));

            services.AddTransient(provider =>
           new Lazy<IOrderRepository>(provider.GetService<IOrderRepository>));
            services.AddTransient(provider =>
                    new Lazy<IOrderDetailsRepository>(provider.GetService<IOrderDetailsRepository>));

            services.AddTransient(provider =>
                    new Lazy<IProduct_AdditionalDetailsRepository>(provider.GetService<IProduct_AdditionalDetailsRepository>));

            services.AddTransient(provider =>
                    new Lazy<IProduct_AttributeRepository>(provider.GetService<IProduct_AttributeRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProduct_ColorsRepository>(provider.GetService<IProduct_ColorsRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProduct_ImageRepository>(provider.GetService<IProduct_ImageRepository>));
            services.AddTransient(provider =>
                   new Lazy<IProduct_UnitRepository>(provider.GetService<IProduct_UnitRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProduct_User_FavouritesRepository>(provider.GetService<IProduct_User_FavouritesRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProduct_variantionRepository>(provider.GetService<IProduct_variantionRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProductEvaluatonRepository>(provider.GetService<IProductEvaluatonRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProductRepository>(provider.GetService<IProductRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProFeaturesRepository>(provider.GetService<IProFeaturesRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProviderEvaluationRepository>(provider.GetService<IProviderEvaluationRepository>));

            services.AddTransient(provider =>
                  new Lazy<IServicesTypeRepository>(provider.GetService<IServicesTypeRepository>));
            services.AddTransient(provider =>
                  new Lazy<ISliderRepository>(provider.GetService<ISliderRepository>));
            services.AddTransient(provider => new Lazy<IDirectorateRepository>(provider.GetService<IDirectorateRepository>));
            services.AddTransient(provider =>   new Lazy<IMarketsRepository>(provider.GetService<IMarketsRepository>));
            services.AddTransient(provider =>   new Lazy<INewsRepository>(provider.GetService<INewsRepository>));
            services.AddTransient(provider =>
                   new Lazy<ISliderImagesRepository>(provider.GetService<ISliderImagesRepository>));

            services.AddTransient(provider =>
                    new Lazy<ISP_AdditionalSectionsRepository>(provider.GetService<ISP_AdditionalSectionsRepository>));
            services.AddTransient(provider =>
              new Lazy<ISP_AddressRepository>(provider.GetService<ISP_AddressRepository>));

            services.AddTransient(provider =>
         new Lazy<ISP_MainClassificationRepository>(provider.GetService<ISP_MainClassificationRepository>));

            services.AddTransient(provider =>
              new Lazy<ISP_ProFeaturesRepository>(provider.GetService<ISP_ProFeaturesRepository>));

            services.AddTransient(provider =>
                   new Lazy<ISP_User_FavouritesRepository>(provider.GetService<ISP_User_FavouritesRepository>));

            services.AddTransient(provider =>
           new Lazy<ISpecialSectionsRepository>(provider.GetService<ISpecialSectionsRepository>));
            services.AddTransient(provider =>
                new Lazy<ISupportRequestRepository>(provider.GetService<ISupportRequestRepository>));
            services.AddTransient(provider =>
                    new Lazy<IProduct_Variant_AttributeRepository>(provider.GetService<IProduct_Variant_AttributeRepository>));
            services.AddTransient(provider => new Lazy<IWorkingHoursRepository>(provider.GetService<IWorkingHoursRepository>));
            services.AddTransient(provider => new Lazy<IWeekdaysRepository>(provider.GetService<IWeekdaysRepository>));
            services.AddTransient(provider => new Lazy<IWorkinPoeriodsRepository>(provider.GetService<IWorkinPoeriodsRepository>));
            services.AddTransient(provider => new Lazy<IUser_BankRepository>(provider.GetService<IUser_BankRepository>));
            services.AddTransient(provider => new Lazy<IBanksRepository>(provider.GetService<IBanksRepository>));

            return services;

        }



    }
}

