using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.Product
{
    public class listgetprodict
    {

        public List<MainClassificationDtoApi> MainClassificationDto { get; set; }
        public List<AdditionalSectionsDtoApi> AdditionalSectionsDto { get; set; }
        public List<MainAndAdditionalClassificationDtoApi> MainAndAdditionalDtoApi { get; set; }
        public List<SpecialSectionDtoApi> SpecialSectionDtoApi { get; set; }
        public List<BrandDtoApi> BrandDto { get; set; }
        public List<AttributeApi> Attribute { get; set; } 
        public List<UnitDtoApi> UnitDto { get; set; }
        public List<ColorDtoApi> ColorDto { get; set; }

    }
    //public class MainAndAdditionalClassificationDtoApi
    //{
    //    public MainClassificationDtoApi MainClassificationDto { get; set; }
    //    public List<AdditionalSectionsDtoApi> AdditionalSectionsDto { get; set; }
    //}
    public class MainAndAdditionalClassificationDtoApi
    {
        public int Id { get; set; }
        public int MainClassificationId { get; set; }
        public int serviceProviderId { get; set; }
        public string MainClassificationName { get; set; }
        public string ImageUrl { get; set; }
      //  public List<AdditionalSectionsDtoApi> AdditionalSectionsDto { get; set; }
        public List<AdditionalSectionsDto2> AdditionalSectionsDto { get; set; }
    }
    public class UnitDtoApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MainClassificationDtoApi
    {
        public int Id { get; set; }
        public string MainClassificationName { get; set; }
        public int MainClassificationId { get; set; }
        public int serviceProviderId { get; set; }
        public string ImageUrl { get; set; }
    } 
    public class SpecialSectionDtoApi
    {
        public int Id { get; set; }
        public string MainClassificationName { get; set; }
        public int MainClassificationId { get; set; }
        public int serviceProviderId { get; set; }
        public string ImageUrl { get; set; }
    }
    public class AdditionalSectionsDtoApi
    {
        public int Id { get; set; }
        public int AdditionalSectionsId { get; set; }
        public String AdditionalSectionsName { get; set; }
        public int Rank { get; set; }
        public string ImageUrl { get; set; }
        public int? ParnetSectionId { get; set; }
    }
    public class AdditionalSectionsDto2
    {
        public int Id { get; set; }
        public int AdditionalSectionsId { get; set; }
        public String AdditionalSectionsName { get; set; }
        public int Rank { get; set; }
        public string ImageUrl { get; set; }
        public int serviceProviderId { get; set; }
        public int? ParnetSectionId { get; set; }
        public List<SpecialSectionsDtoApi> specialSectionsDto { get; set; }
    }

    public class SpecialSectionsDtoApi
    {
        public int Id { get; set; }
        public int serviceProviderId { get; set; }
        public int? AdditionalSectionsId { get; set; }
        public String SpecialSectionName { get; set; }
        public string ImageUrl { get; set; }
        public int? Rank { get; set; }
        public int? MainClassificationId { get; set; }
    }
    public class BrandDtoApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }  
    public class AttributeApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }   
    public class ColorDtoApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
    }
}
