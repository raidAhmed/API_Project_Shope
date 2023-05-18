 
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated UnitSizeController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.UnitSize;
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
//    public class UnitSizeController : BaseApiController
//    {
//        //private readonly ILogger<UnitSizeController> logger;

//        //public UnitSizeController(IServiceManager serviceManager, ILogger<UnitSizeController> logger)
//        //{
//        //    ServiceManager = serviceManager;
//        //    this.logger = logger;
//        //}

//        // GET: api/UnitSize/Get
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.UnitSizeService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/UnitSize/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.UnitSizeService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }


//        // GET api/UnitSize/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.UnitSizeService.GetById(Id);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

            

//        // POST api/UnitSize
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] UnitSizeCreateDto entity)
//        {

//            UnitSizeCreateValidator validator = new UnitSizeCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.UnitSizeService.Add(entity);

                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/UnitSize/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] UnitSizeUpdateDto entity)
//        {

//            UnitSizeUpdateValidator validator = new UnitSizeUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.UnitSizeService.Update(entity);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/UnitSize/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.UnitSizeService.Remove(Id);
                        
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
