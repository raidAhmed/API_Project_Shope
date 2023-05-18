using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Thumbnail { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Current_Stock { get; set; }//Quantity
        public int? Min_qty { get; set; }//Quantity
        public int? Minimum_Order_Qty { get; set; }//اقل كمية طلب
        public bool Negotiation { get; set; }
        public string? Code { get; set; }
        public bool Free_Shipping { get; set; }
        public bool Refundable { get; set; }
        public bool Multiply_Qty { get; set; }
        public string? Video_Provider { get; set; }
        public string? Video_Url { get; set; }
        public int? Discount { get; set; }
        public String? DiscountType { get; set; }
        public string? Details { get; set; }

        public string? VideoUrl { get; set; }
        public bool ProductStates { get; set; }
        public string? Add_By { get; set; }
        // from Brand
        public int? BrandId { get; set; }//العلامة  التجارية
        // from Activety Type
        public int? ActivityTypeId { get; set; }
        //from MainClassfication
        public int? MainClassificationId { get; set; }
        // from AdditionalSections
        public int? AdditionalSectionsId { get; set; }
        // from SpecialSections
        public int? SpecialSectionsId { get; set; }
        // from ServiceProvider
        public int? ServiceProviderId { get; set; }
        //from User
        public String? UserId { get; set; }
        public bool Active { get; set; }

        public List<Offer> Offers { get; set; }
        public ActivityType ActivityType { get; set; }
        public MainClassification MainClassification { get; set; }
        public AdditionalSections AdditionalSections { get; set; }
        public SpecialSections SpecialSections { get; set; }
        public ServiceProvider ServiceProvider { get; set; }


        public Brand Brand { get; set; }
        public User User { get; set; }

        // to Product
        public List<Product_AdditionalDetails> Product_AdditionalDetails { get; set; }

        // to Product_Image

        public List<Product_Image> product_Images { get; set; }


        // to Product_Colors
        public List<Product_Colors> Product_Colors { get; set; }
        // to Product_Variant_Attribute
        public List<Product_Variant_Attribute> product_Variant_Attributes { get; set; }

        // to Product_variantion
        public List<Product_variantion> product_Variantions { get; set; }

        // to  ProductEvaluaton
        public List<ProductEvaluaton> productEvaluatons { get; set; }
        //to Product_Unit
        public List<Product_Unit> product_Units { get; set; }
        // to Product_User_Favourites
        public List<Product_User_Favourites> product_User_Favourites { get; set; }

        public List<CartDetails> CartDetails { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        //  public List<Order> Orders { get; set; }   
        public Product()
        {
            Minimum_Order_Qty = 1;
            Min_qty = 1;
            Discount = 0;
            DiscountType = "1";
            Current_Stock = 1;
            Active = true;
            ProductStates = true;
            Free_Shipping = false;
            Refundable = false;
            Multiply_Qty = false;
            Negotiation = false;
        }

    }
}
