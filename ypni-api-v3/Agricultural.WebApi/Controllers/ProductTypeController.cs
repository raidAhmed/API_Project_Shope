 
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated ProductTypeController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.ProductType;
//using Agricultural.Application.Wrapper;
//using Agricultural.Application.Constants;
//using Agricultural.Application.Constants.Permissions;
//using Agricultural.Application.Common;
//using FluentValidation.Results;
//using System.Text;

//namespace Agricultural.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductTypeController : BaseApiController
//    {
//        //private readonly ILogger<ProductTypeController> logger;

//        //public ProductTypeController(IServiceManager serviceManager, ILogger<ProductTypeController> logger)
//        //{
//        //    ServiceManager = serviceManager;
//        //    this.logger = logger;
//        //}

//        // GET: api/ProductType/Get
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.ProductTypeService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/ProductType/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.ProductTypeService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // GET ProductType/GetDDL
//        [Authorize]
//        [HttpGet("GetDDL")]
//        public async Task<IActionResult> GetDDL()
//        {
//            var result = await ServiceManager.ProductTypeService.GetDDL();
            
//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }   

//        // GET api/ProductType/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.ProductTypeService.GetById(Id);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

            

//        // POST api/ProductType
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] ProductTypeCreateDto entity)
//        {

//            ProductTypeCreateValidator validator = new ProductTypeCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ProductTypeService.Add(entity);

                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/ProductType/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] ProductTypeUpdateDto entity)
//        {

//            ProductTypeUpdateValidator validator = new ProductTypeUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ProductTypeService.Update(entity);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/ProductType/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.ProductTypeService.Remove(Id);
                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }
//    }
//}
