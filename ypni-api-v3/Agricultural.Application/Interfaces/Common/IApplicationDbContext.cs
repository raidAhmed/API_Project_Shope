using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;


namespace Agricultural.Application.Interfaces.Common
{
    public interface IApplicationDbContext
    {
        DbSet<ActivityType> ActivityType { get; }
        DbSet<AdditionalSections> AdditionalSections { get; }
        DbSet<Brand> Brand { get; }
        DbSet<BusinessCommercial> BusinessCommercial { get; }
        DbSet<Cart> Cart { get; }
        DbSet<CheckOut> CheckOut { get; }
        DbSet<City> City { get; }
        DbSet<Directorate> Directorate { get; }
        DbSet<Color> Color { get; }
        DbSet<ComplainantToParty> ComplainantToParty { get; }
        //DbSet<ConsultationRequest> ConsultationRequest { get; }
        //DbSet<ConsultationRequestPic> ConsultationRequestPic { get; }
        DbSet<Currency> Currency { get; }
        DbSet<Farmer> Farmer { get; }
        DbSet<MainClassification> MainClassification { get; }
        DbSet<ManufactureCompany> ManufactureCompany { get; }
        DbSet<Offer> Offer { get; }
        DbSet<OfficialParty> OfficialParty { get; }
        DbSet<Order> Order { get; }
        DbSet<OrderDetails> OrderDetails { get; }
        DbSet<Product> Product { get; }
        DbSet<Product_AdditionalDetails> Product_AdditionalDetails { get; }
        DbSet<Product_Attribute> Product_Attribute { get; }
        DbSet<Product_Colors> Product_Colors { get; }
        DbSet<Product_Image> Product_Image { get; }
        DbSet<Product_Unit> Product_Unit { get; }
        DbSet<Product_User_Favourites> Product_User_Favourites { get; }
        DbSet<Product_Variant_Attribute> Product_Variant_Attribute { get; }
        DbSet<Product_variantion> Product_variantion { get; }
        DbSet<ProductEvaluaton> ProductEvaluaton { get; }
        DbSet<ProFeatures> ProFeatures { get; }
        DbSet<ProviderEvaluation> ProviderEvaluation { get; }
        DbSet<ServiceProvider> ServiceProvider { get; }
        DbSet<ServicesType> ServicesType { get; }
        DbSet<SP_AdditionalSections> SP_AdditionalSections { get; }
        DbSet<SP_Address> SP_Address { get; }

        DbSet<SP_MainClassification> SP_MainClassification { get; }
        DbSet<SP_ProFeatures> SP_ProFeatures { get; }
        DbSet<SP_User_Favourites> SP_User_Favourites { get; }
        DbSet<SpecialSections> SpecialSections { get; }
        DbSet<SupportRequest> SupportRequest { get; }
        DbSet<Unit> Unit { get; }
        //  DbSet<User> User { get; }
        DbSet<Slider> Slider { get; }
        DbSet<SliderImages> SliderImages { get; }
        DbSet<CartDetails> CartDetails { get; }
        DbSet<Markets> Markets { get; }
        DbSet<News> News { get; }
        DbSet<Weekdays> Weekdays { get; }
        DbSet<WorkingHours> WorkingHours { get; }
        DbSet<WorkinPoeriods> WorkinPoeriods { get; }
       
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
