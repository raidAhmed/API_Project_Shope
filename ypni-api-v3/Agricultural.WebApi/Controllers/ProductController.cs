
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.ProductEvaluaton;
using Agricultural.Application.DTOs.Product_User_Favourites;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.WebApi.ViewModel;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.ProductService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpPost("GetAllProApiBymainclassficationid")]
        public async Task<IActionResult> GetAllProApiBymainclassficationid(ProductByMainclassficationIdAndAddetionalVm mainid)
        {
            var result = await ServiceManager.ProductService.GetAllProById(x=>x.MainClassificationId==mainid.mainClassificationId && x.Active == false&& x.ProductStates == true);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpPost("GetAllProApiByAddtionalid")]
        public async Task<IActionResult> GetAllProApiByAddtionalid(ProductByMainclassficationIdAndAddetionalVm adddtionalid)
        {
            var result = await ServiceManager.ProductService.GetAllProById(x=>x.AdditionalSectionsId==adddtionalid.mainClassificationId && x.Active == false&& x.ProductStates == true);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
       
        [HttpPost("GetAllProApiByBrand")]
        public async Task<IActionResult> GetAllProApiByBrand(ProductByBrandVm brandid)
        {
            var result = await ServiceManager.ProductService.GetAllProById(x=>x.BrandId==brandid.brandId && x.ProductStates == true&& x.Active == false);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        } 

        [HttpGet("GetAllProApiBySPSeller")]
        public async Task<IActionResult> GetAllProApiBySPSeller(int ID)
        {
            var result = await ServiceManager.ProductService.GetAllProById(x => x.ServiceProviderId == ID && x.ProductStates == true);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        [HttpGet("GetAllProApiBySP")]
        public async Task<IActionResult> GetAllProApiBySP(int ID)
        {
            var result = await ServiceManager.ProductService.GetAllProById(x => x.ServiceProviderId == ID && x.ProductStates == true && x.Active == false);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpGet("GetAllProApi")]
        public async Task<IActionResult> GetAllProApi()
        {
            var result = await ServiceManager.ProductService.GetAllProApi();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpPost("GetAllByServiceProviderIdAndAdditionalSectionsId")]
        public async Task<IActionResult> GetAllByServiceProviderIdAndMainClassificationId(ProductByServerProviderIdAndMainclassficationIdVm entity)
        {
            var result = await ServiceManager.ProductService.GetAllByServiceProviderIdAndMainClassificationId(entity.mainClassificationId, entity.serviceProviderId);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        } 
       
             [HttpPost("GetAllByServiceProviderIdAndMainClassificationId")]
        public async Task<IActionResult> GetAllByServiceProviderIdAndAdditionalSectionsId(ProductByServerProviderIdAndMainclassficationIdVm entity)
        {

            var result = await ServiceManager.ProductService.GetAllByServiceProviderIdAndAdditionalSectionsId(entity.mainClassificationId, entity.serviceProviderId);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        } 
       

        [HttpGet("GetProduct/id")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await ServiceManager.ProductService.GetAllProById(X=>X.Id==id&&X.ProductStates==true&&X.Active==false);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return null;
            }


        }
          [HttpGet("GetProductPagination")]
        public async Task<IActionResult> GetProductPagination(int skip,int take)
        {
            var result = await ServiceManager.ProductService.GetAllProPagination(x=>x.ProductStates==true&&x.Active==false, skip,take);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return null;
            }


        }

        // POST: api/ActivityType/GetDt

        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.ProductService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpGet("GetAlllistforAdd")]
        public async Task<IActionResult> GetAlllistforAdd()
        {
            var result = await ServiceManager.ProductService.GetAlllistforAdd();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }

        }

        // GET ActivityType/GetDDL

        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.ProductService.GetDDL();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        // GET api/ActivityType/5

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await ServiceManager.ProductService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        [HttpPost("AddApi")]
        public async Task<IActionResult> AddApi([FromBody] productdtoADDapi entity)
        {

             if (entity == null) return BadRequest("null");
            try
            {

                //  return Ok(entity);

                var result = await ServiceManager.ProductService.AddApi(entity);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Status);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            /* var result = await ServiceManager.ProductService.AddApi(entity);

             if (result.Succeeded)
             {
                 return Ok(result);
             }
             else
             {
                 return BadRequest(result.Status);
             }*/

        }

        // POST api/ActivityType

        [HttpPost("PostAddproduct")]
        public async Task<IActionResult> PostAddproduct([FromBody] productdtoADDapi entity)
        {


             if (entity == null) return BadRequest("null");
            try
            {
               
              //  return Ok(entity);

               var  result=await ServiceManager.ProductService.AddApi(entity);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Status);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] ProductDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.ProductService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPost("ChangeStateForDelete")]
        public async Task<IActionResult> Delete(int Id)
        { 
            var obj = new ProductDto();
            obj.Id = Id;
            var result = await ServiceManager.ProductService.ChangeStateForProduct(obj);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }    
        [HttpPost("ChangeActive")]
        public async Task<IActionResult> ChangeActive(int Id)
        {
            var obj = new ProductDto();
            obj.Id = Id;    
               var result = await ServiceManager.ProductService.ChangeActive(obj);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }      
        [HttpGet("search")]
        public async Task<IActionResult> Search(string Name) 
        {
              
               var result = await ServiceManager.ProductService.Find(x=>x.Name.Contains(Name)&&x.ProductStates==true&&x.Active==false); 

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

    }
}
