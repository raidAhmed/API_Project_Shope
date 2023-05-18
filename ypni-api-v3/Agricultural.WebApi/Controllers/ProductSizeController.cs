 
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated ProductSizeController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.ProductSize;
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
//    public class ProductSizeController : BaseApiController
//    {
//        //private readonly ILogger<ProductSizeController> logger;

//        //public ProductSizeController(IServiceManager serviceManager, ILogger<ProductSizeController> logger)
//        //{
//        //    ServiceManager = serviceManager;
//        //    this.logger = logger;
//        //}

//        // GET: api/ProductSize/Get
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.ProductSizeService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/ProductSize/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.ProductSizeService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }


//        // GET api/ProductSize/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.ProductSizeService.GetById(Id);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

            

//        // POST api/ProductSize
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] ProductSizeCreateDto entity)
//        {

//            ProductSizeCreateValidator validator = new ProductSizeCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ProductSizeService.Add(entity);

                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/ProductSize/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] ProductSizeUpdateDto entity)
//        {

//            ProductSizeUpdateValidator validator = new ProductSizeUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ProductSizeService.Update(entity);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/ProductSize/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.ProductSizeService.Remove(Id);
                        
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
