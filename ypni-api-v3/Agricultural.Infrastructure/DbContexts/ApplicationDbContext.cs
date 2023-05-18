using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Agricultural.Infrastructure.Identity;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.EntityConfiguration;
using Agricultural.Domain.Entity.Base;
using Microsoft.AspNetCore.Identity;

namespace Agricultural.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ActivityType> ActivityType { get; private set; }

        public DbSet<AdditionalSections> AdditionalSections { get; private set; }

        public DbSet<Brand> Brand { get; private set; }

        public DbSet<BusinessCommercial> BusinessCommercial { get; private set; }

        public DbSet<Cart> Cart { get; private set; }

        public DbSet<CheckOut> CheckOut { get; private set; }

        public DbSet<City> City { get; private set; }

        public DbSet<Color> Color { get; private set; }

        public DbSet<ComplainantToParty> ComplainantToParty { get; private set; }

        //public DbSet<ConsultationRequest> ConsultationRequest { get; private set; }

        //public DbSet<ConsultationRequestPic> ConsultationRequestPic { get; private set; }

        public DbSet<Currency> Currency { get; private set; }

        public DbSet<Farmer> Farmer { get; private set; }

        public DbSet<MainClassification> MainClassification { get; private set; }

        public DbSet<ManufactureCompany> ManufactureCompany { get; private set; }

        public DbSet<Offer> Offer { get; private set; }

        public DbSet<OfficialParty> OfficialParty { get; private set; }

        public DbSet<Order> Order { get; private set; }
        public DbSet<OrderDetails> OrderDetails { get; private set; }

        public DbSet<Product> Product { get; private set; }

        public DbSet<Product_AdditionalDetails> Product_AdditionalDetails { get; private set; }

        public DbSet<Product_Attribute> Product_Attribute { get; private set; }

        public DbSet<Product_Colors> Product_Colors { get; private set; }

        public DbSet<Product_Image> Product_Image { get; private set; }

        public DbSet<Product_Unit> Product_Unit { get; private set; }

        public DbSet<Product_User_Favourites> Product_User_Favourites { get; private set; }

        public DbSet<Product_Variant_Attribute> Product_Variant_Attribute { get; private set; }

        public DbSet<Product_variantion> Product_variantion { get; private set; }

        public DbSet<ProductEvaluaton> ProductEvaluaton { get; private set; }

        public DbSet<ProFeatures> ProFeatures { get; private set; }

        public DbSet<ProviderEvaluation> ProviderEvaluation { get; private set; }

        public DbSet<ServiceProvider> ServiceProvider { get; private set; }

        public DbSet<ServicesType> ServicesType { get; private set; }

        public DbSet<SP_AdditionalSections> SP_AdditionalSections { get; private set; }

        public DbSet<SP_Address> SP_Address { get; private set; }

        public DbSet<SP_MainClassification> SP_MainClassification { get; private set; }

        public DbSet<SP_ProFeatures> SP_ProFeatures { get; private set; }

        public DbSet<SP_User_Favourites> SP_User_Favourites { get; private set; }

        public DbSet<SpecialSections> SpecialSections { get; private set; }

        public DbSet<SupportRequest> SupportRequest { get; private set; }

        public DbSet<Unit> Unit { get; private set; }

        public DbSet<Slider> Slider { get; private set; }

        public DbSet<SliderImages> SliderImages { get; private set; }

        public DbSet<CartDetails> CartDetails { get; private set; }

        public DbSet<Directorate> Directorate { get; private set; }

        public DbSet<Markets> Markets { get; private set; }

        public DbSet<News> News { get; private set; }

        public DbSet<Banks> Banks { get; private set; }

        public DbSet<User_Bank> User_Bank { get; private set; }
        public DbSet<Weekdays> Weekdays { get; private set; }


        public DbSet<WorkingHours> WorkingHours { get; private set; }


        public DbSet<WorkinPoeriods> WorkinPoeriods { get; private set; }




        // اضافة لمزود الخدمة 
        // اضافة  المميزات 
        // اضافة للعلاقه مع المميزات 
        // اضافة انواع مزودي الخدمة 
        // اضافة العلاقه مع انواع  مزودي الخدمة 

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedByUser = 1; //_currentUserService.UserId ?? "1";
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = 1; //_cu//rrentUserService.UserId;
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = "mnm"; //_currentUserService.UserId;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        entry.Entity.IsDeleted = true;
                        break;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new RoleConfiguration().Configure(modelBuilder.Entity<IdentityRole>());
            new UserRoleConfiguration().Configure(modelBuilder.Entity<IdentityUserRole<string>>());
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            //{ Id = "ca34737e-e863-40aa-a82f-adbd3207988a", Name = "Admin", NormalizedName = "ADMIN".ToUpper(), ConcurrencyStamp = "b9fce677-ff9b-4d55-93b0-dcb97d12b11c" });
            //var hasher = new PasswordHasher<User>();
            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
            //    UserName = "Quantum",
            //    Email = "Agricultural@Gmail.com",
            //    FirstName = "شركة",
            //    LastName = "كوانتم",
            //    Active = true,
            //    Status = false,
            //    NormalizedUserName = "QUANTUM",
            //    NormalizedEmail = "AGRICULTURAL@GMAIL.COM",
            //    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
            //}) ;
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "ca34737e-e863-40aa-a82f-adbd3207988a",
            //    UserId = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
            //});
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionalSectionsConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessCommercialConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CheckOutConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorateConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new ComplainantToPartyConfiguration());
       //     modelBuilder.ApplyConfiguration(new ConsultationRequestConfiguration());
        //    modelBuilder.ApplyConfiguration(new ConsultationRequestPicConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new FarmerConfiguration());
            modelBuilder.ApplyConfiguration(new MainClassificationConfiguration());
            modelBuilder.ApplyConfiguration(new ManufactureCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new OfficialPartyConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new Product_AdditionalDetailsConfigration());
            modelBuilder.ApplyConfiguration(new Product_AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new Product_ColorsConfigration());
            modelBuilder.ApplyConfiguration(new Product_ImageConfigration());
            modelBuilder.ApplyConfiguration(new Product_UnitConfigration());
            modelBuilder.ApplyConfiguration(new Product_User_FavouritesConfigration());
            modelBuilder.ApplyConfiguration(new Product_Variant_AttributeConfigration());
            modelBuilder.ApplyConfiguration(new Product_variantionConfigration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEvaluatonConfigration());
            modelBuilder.ApplyConfiguration(new ProFeaturesConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderEvaluationConfigration());
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SP_AdditionalSectionsConfiguration());
            modelBuilder.ApplyConfiguration(new SP_AdressConfiguration());
            modelBuilder.ApplyConfiguration(new SP_MainClassificationConfiguration());
            modelBuilder.ApplyConfiguration(new SP_ProFeaturesConfiguration());
            modelBuilder.ApplyConfiguration(new SP_User_FavouritesConfigration());
            modelBuilder.ApplyConfiguration(new SpecialSectionsConfiguration());
            modelBuilder.ApplyConfiguration(new SupportRequestConfiguration());
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new SliderImagesConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new CartDetailsConfigration());
            modelBuilder.ApplyConfiguration(new MarketsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new WeekdaysConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingHoursConfiguration());
            modelBuilder.ApplyConfiguration(new WorkinPoeriodsConfiguration());
            modelBuilder.ApplyConfiguration(new BanksConfiguration());
            modelBuilder.ApplyConfiguration(new User_BankConfiguration());

            // OnModelCreatingPartial(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }
     //   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
