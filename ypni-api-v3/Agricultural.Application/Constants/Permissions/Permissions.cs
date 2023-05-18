 
/////////////////////////////////////
///         Ibrahim AL-afif       ///
///         ib2050a@gmail.com     ///
///         +967 777 384 772      ///
//   generated  Permissions.cs   ///
/////////////////////////////////////
using System.Collections.Generic;

namespace Agricultural.Application.Constants.Permissions
{
public static class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.Read",
            $"Permissions.{module}.Update",
            $"Permissions.{module}.Delete",
        };
    }

    public static class ActivityPermissions
    {
        public const string Read = "Permissions.Activity.Read";
        public const string Create = "Permissions.Activity.Create";
        public const string Update = "Permissions.Activity.Update";
        public const string Delete = "Permissions.Activity.Delete";
    }

    public static class ActivityTypePermissions
    {
        public const string Read = "Permissions.ActivityType.Read";
        public const string Create = "Permissions.ActivityType.Create";
        public const string Update = "Permissions.ActivityType.Update";
        public const string Delete = "Permissions.ActivityType.Delete";
    }

    public static class AddressPermissions
    {
        public const string Read = "Permissions.Address.Read";
        public const string Create = "Permissions.Address.Create";
        public const string Update = "Permissions.Address.Update";
        public const string Delete = "Permissions.Address.Delete";
    }

    public static class AdvisoryBodyPermissions
    {
        public const string Read = "Permissions.AdvisoryBody.Read";
        public const string Create = "Permissions.AdvisoryBody.Create";
        public const string Update = "Permissions.AdvisoryBody.Update";
        public const string Delete = "Permissions.AdvisoryBody.Delete";
    }

    public static class BasicClassificationPermissions
    {
        public const string Read = "Permissions.BasicClassification.Read";
        public const string Create = "Permissions.BasicClassification.Create";
        public const string Update = "Permissions.BasicClassification.Update";
        public const string Delete = "Permissions.BasicClassification.Delete";
    }

    public static class BusinessCommercialPermissions
    {
        public const string Read = "Permissions.BusinessCommercial.Read";
        public const string Create = "Permissions.BusinessCommercial.Create";
        public const string Update = "Permissions.BusinessCommercial.Update";
        public const string Delete = "Permissions.BusinessCommercial.Delete";
    }

    public static class CartPermissions
    {
        public const string Read = "Permissions.Cart.Read";
        public const string Create = "Permissions.Cart.Create";
        public const string Update = "Permissions.Cart.Update";
        public const string Delete = "Permissions.Cart.Delete";
    }

    public static class CategoryPermissions
    {
        public const string Read = "Permissions.Category.Read";
        public const string Create = "Permissions.Category.Create";
        public const string Update = "Permissions.Category.Update";
        public const string Delete = "Permissions.Category.Delete";
    }

    public static class CheckOutPermissions
    {
        public const string Read = "Permissions.CheckOut.Read";
        public const string Create = "Permissions.CheckOut.Create";
        public const string Update = "Permissions.CheckOut.Update";
        public const string Delete = "Permissions.CheckOut.Delete";
    }

    public static class CityPermissions
    {
        public const string Read = "Permissions.City.Read";
        public const string Create = "Permissions.City.Create";
        public const string Update = "Permissions.City.Update";
        public const string Delete = "Permissions.City.Delete";
    }

    public static class ClassificationAttributePermissions
    {
        public const string Read = "Permissions.ClassificationAttribute.Read";
        public const string Create = "Permissions.ClassificationAttribute.Create";
        public const string Update = "Permissions.ClassificationAttribute.Update";
        public const string Delete = "Permissions.ClassificationAttribute.Delete";
    }

    public static class ClassificationCategoryPermissions
    {
        public const string Read = "Permissions.ClassificationCategory.Read";
        public const string Create = "Permissions.ClassificationCategory.Create";
        public const string Update = "Permissions.ClassificationCategory.Update";
        public const string Delete = "Permissions.ClassificationCategory.Delete";
    }

    public static class CollectionCategoryPermissions
    {
        public const string Read = "Permissions.CollectionCategory.Read";
        public const string Create = "Permissions.CollectionCategory.Create";
        public const string Update = "Permissions.CollectionCategory.Update";
        public const string Delete = "Permissions.CollectionCategory.Delete";
    }

    public static class ConsultationRequestPermissions
    {
        public const string Read = "Permissions.ConsultationRequest.Read";
        public const string Create = "Permissions.ConsultationRequest.Create";
        public const string Update = "Permissions.ConsultationRequest.Update";
        public const string Delete = "Permissions.ConsultationRequest.Delete";
    }

    public static class ManufactureCompanyPermissions
    {
        public const string Read = "Permissions.ManufactureCompany.Read";
        public const string Create = "Permissions.ManufactureCompany.Create";
        public const string Update = "Permissions.ManufactureCompany.Update";
        public const string Delete = "Permissions.ManufactureCompany.Delete";
    }

    public static class MarketPermissions
    {
        public const string Read = "Permissions.Market.Read";
        public const string Create = "Permissions.Market.Create";
        public const string Update = "Permissions.Market.Update";
        public const string Delete = "Permissions.Market.Delete";
    }

    public static class MarketPricePermissions
    {
        public const string Read = "Permissions.MarketPrice.Read";
        public const string Create = "Permissions.MarketPrice.Create";
        public const string Update = "Permissions.MarketPrice.Update";
        public const string Delete = "Permissions.MarketPrice.Delete";
    }

    public static class MultiActivityCategoryPermissions
    {
        public const string Read = "Permissions.MultiActivityCategory.Read";
        public const string Create = "Permissions.MultiActivityCategory.Create";
        public const string Update = "Permissions.MultiActivityCategory.Update";
        public const string Delete = "Permissions.MultiActivityCategory.Delete";
    }

    public static class NewsPaperPermissions
    {
        public const string Read = "Permissions.NewsPaper.Read";
        public const string Create = "Permissions.NewsPaper.Create";
        public const string Update = "Permissions.NewsPaper.Update";
        public const string Delete = "Permissions.NewsPaper.Delete";
    }

    public static class OfferPermissions
    {
        public const string Read = "Permissions.Offer.Read";
        public const string Create = "Permissions.Offer.Create";
        public const string Update = "Permissions.Offer.Update";
        public const string Delete = "Permissions.Offer.Delete";
    }

    public static class OrderPermissions
    {
        public const string Read = "Permissions.Order.Read";
        public const string Create = "Permissions.Order.Create";
        public const string Update = "Permissions.Order.Update";
        public const string Delete = "Permissions.Order.Delete";
    }

    public static class OtherCategoryPermissions
    {
        public const string Read = "Permissions.OtherCategory.Read";
        public const string Create = "Permissions.OtherCategory.Create";
        public const string Update = "Permissions.OtherCategory.Update";
        public const string Delete = "Permissions.OtherCategory.Delete";
    }

    public static class OtherElementPermissions
    {
        public const string Read = "Permissions.OtherElement.Read";
        public const string Create = "Permissions.OtherElement.Create";
        public const string Update = "Permissions.OtherElement.Update";
        public const string Delete = "Permissions.OtherElement.Delete";
    }

    public static class PriceQuantityPermissions
    {
        public const string Read = "Permissions.PriceQuantity.Read";
        public const string Create = "Permissions.PriceQuantity.Create";
        public const string Update = "Permissions.PriceQuantity.Update";
        public const string Delete = "Permissions.PriceQuantity.Delete";
    }

    public static class ProcessTrackingPermissions
    {
        public const string Read = "Permissions.ProcessTracking.Read";
        public const string Create = "Permissions.ProcessTracking.Create";
        public const string Update = "Permissions.ProcessTracking.Update";
        public const string Delete = "Permissions.ProcessTracking.Delete";
    }

    public static class ProductPermissions
    {
        public const string Read = "Permissions.Product.Read";
        public const string Create = "Permissions.Product.Create";
        public const string Update = "Permissions.Product.Update";
        public const string Delete = "Permissions.Product.Delete";
    }

    public static class ProductColorPermissions
    {
        public const string Read = "Permissions.ProductColor.Read";
        public const string Create = "Permissions.ProductColor.Create";
        public const string Update = "Permissions.ProductColor.Update";
        public const string Delete = "Permissions.ProductColor.Delete";
    }

    public static class ProductImagePermissions
    {
        public const string Read = "Permissions.ProductImage.Read";
        public const string Create = "Permissions.ProductImage.Create";
        public const string Update = "Permissions.ProductImage.Update";
        public const string Delete = "Permissions.ProductImage.Delete";
    }

    public static class ProductSizePermissions
    {
        public const string Read = "Permissions.ProductSize.Read";
        public const string Create = "Permissions.ProductSize.Create";
        public const string Update = "Permissions.ProductSize.Update";
        public const string Delete = "Permissions.ProductSize.Delete";
    }

    public static class ProductTypePermissions
    {
        public const string Read = "Permissions.ProductType.Read";
        public const string Create = "Permissions.ProductType.Create";
        public const string Update = "Permissions.ProductType.Update";
        public const string Delete = "Permissions.ProductType.Delete";
    }

    public static class SalesPermissions
    {
        public const string Read = "Permissions.Sales.Read";
        public const string Create = "Permissions.Sales.Create";
        public const string Update = "Permissions.Sales.Update";
        public const string Delete = "Permissions.Sales.Delete";
    }

    public static class ServiceProvIderPermissions
    {
        public const string Read = "Permissions.ServiceProvIder.Read";
        public const string Create = "Permissions.ServiceProvIder.Create";
        public const string Update = "Permissions.ServiceProvIder.Update";
        public const string Delete = "Permissions.ServiceProvIder.Delete";
    }

    public static class SubCategoryPermissions
    {
        public const string Read = "Permissions.SubCategory.Read";
        public const string Create = "Permissions.SubCategory.Create";
        public const string Update = "Permissions.SubCategory.Update";
        public const string Delete = "Permissions.SubCategory.Delete";
    }

    public static class SupportingEntityPermissions
    {
        public const string Read = "Permissions.SupportingEntity.Read";
        public const string Create = "Permissions.SupportingEntity.Create";
        public const string Update = "Permissions.SupportingEntity.Update";
        public const string Delete = "Permissions.SupportingEntity.Delete";
    }

    public static class SupportRequestPermissions
    {
        public const string Read = "Permissions.SupportRequest.Read";
        public const string Create = "Permissions.SupportRequest.Create";
        public const string Update = "Permissions.SupportRequest.Update";
        public const string Delete = "Permissions.SupportRequest.Delete";
    }

    public static class UnitPermissions
    {
        public const string Read = "Permissions.Unit.Read";
        public const string Create = "Permissions.Unit.Create";
        public const string Update = "Permissions.Unit.Update";
        public const string Delete = "Permissions.Unit.Delete";
    }

    public static class UnitSizePermissions
    {
        public const string Read = "Permissions.UnitSize.Read";
        public const string Create = "Permissions.UnitSize.Create";
        public const string Update = "Permissions.UnitSize.Update";
        public const string Delete = "Permissions.UnitSize.Delete";
    }

    public static class UserPermissions
    {
        public const string Read = "Permissions.User.Read";
        public const string Create = "Permissions.User.Create";
        public const string Update = "Permissions.User.Update";
        public const string Delete = "Permissions.User.Delete";
    }

}
}
