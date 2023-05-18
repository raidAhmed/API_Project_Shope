using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Agricultural.Application.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المنتج")]
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
        [NotMapped]
        //[Required(ErrorMessage = " أختر  صورة  ")]
        public IFormFile File { get; set; }
        public List<Product_variantionDto> Product_variantionDtoList { get; set; }
        public List<imgesproduct> imgesproductList { get; set; }
        public List<int> AdditionalSectionsIdd { get; set; }
        public List<SP_AdditionalSectionsDto> listAdditionalSectionsIdd { get; set; }

        public List<Product_ColorsDtoapi> Colorlist { get; set; }
        public List<Product_ImageDto> Product_ImageDtolist { get; set; }
    }

    public class imgesproduct
    {
        public IFormFile File { get; set; }

    }
}
