using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.DTOs.Product_variantion;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product
{
    public class productdtoapi
    {
        public List<Product_variantionDtoapi> Product_variantionDtoList { get; set; }
        public List<Product_ColorsDtoapi> colorlist { get; set; }
        public ProductDtoinapi Productinfo { get; set; }
    }
    public class productdtoADDapi
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public int? ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; } = null!;
        public int? MainClassificationId { get; set; }
        public string MainClassificationName { get; set; } = null!;
        public int? AdditionalSectionsId { get; set; }
        public string AdditionalSectionsName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Discount { get; set; }
        public string DiscountType { get; set; } = null!;
        public string? UserId { get; set; }

        public int? UnitId { get; set; }
        public int? BrandId { get; set; }
        public List<string> lang { get; set; } = new List<string>() { "en", "sa" };
        public List<ColorDtoApi> Colors { get; set; }
        public List<string> images { get; set; }
        public string? Thumbnail { get; set; }
        //    public IFormFile[]  images { get; set; }
        //    public IFormFile thumbnail { get; set; }
        public bool colors_active { get; set; }
        public string? Video_Url { get; set; }
        public string? Video_Provider { get; set; }
        public int? Current_Stock { get; set; }
        public string? Code { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? SpecialSectionsId { get; set; } 
        public int? Min_qty { get; set; }
        public bool ProductStates { get; set; }
        public bool Free_Shipping { get; set; }
        public bool Refundable { get; set; }
        public bool Negotiation { get; set; }

        public int? Minimum_Order_Qty { get; set; }
        public List<choice_options> choice_options { get; set; }
        public List<variation> variation { get; set; }
        public bool isFafo { get; set; }
        public int EvaluteNum { get; set; }
        public bool Active { get; set; }
        public string RatingPro { get; set; }
        public productdtoADDapi()
        {
            ProductStates = true;
            Free_Shipping = false;
            Refundable = false;
            Negotiation = false;
        }


    }
    public class choice_options
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> options { get; set; }

    }
    public class variation
    {
        public int? Id { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public string? SKU { get; set; }
        public int qty { get; set; }
        public int? ProductId { get; set; }

    }
    public class images
    {
        public IFormFile File { get; set; }

    }


}
