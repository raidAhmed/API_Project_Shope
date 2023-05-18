 
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated BasicClassificationController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.BasicClassification;
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
//    public class BasicClassificationController : BaseApiController
//    {
//        //private readonly ILogger<BasicClassificationController> logger;

//        //public BasicClassificationController(IServiceManager serviceManager, ILogger<BasicClassificationController> logger)
//        //{
//        //    ServiceManager = serviceManager;
//        //    this.logger = logger;
//        //}

//        // GET: api/BasicClassification/Get
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.BasicClassificationService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/BasicClassification/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.BasicClassificationService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // GET BasicClassification/GetDDL
//        [Authorize]
//        [HttpGet("GetDDL")]
//        public async Task<IActionResult> GetDDL()
//        {
//            var result = await ServiceManager.BasicClassificationService.GetDDL();
            
//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }   

//        // GET api/BasicClassification/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.BasicClassificationService.GetById(Id);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

            

//        // POST api/BasicClassification
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] BasicClassificationCreateDto entity)
//        {

//            BasicClassificationCreateValidator validator = new BasicClassificationCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.BasicClassificationService.Add(entity);

                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/BasicClassification/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] BasicClassificationUpdateDto entity)
//        {

//            BasicClassificationUpdateValidator validator = new BasicClassificationUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.BasicClassificationService.Update(entity);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/BasicClassification/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.BasicClassificationService.Remove(Id);
                        
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
