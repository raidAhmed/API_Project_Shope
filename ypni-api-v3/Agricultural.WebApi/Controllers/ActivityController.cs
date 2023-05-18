 
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated ActivityController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.Activity;
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
//    public class ActivityController : BaseApiController
//    {
//        //private readonly ILogger<ActivityController> logger;

//        //public ActivityController(IServiceManager serviceManager, ILogger<ActivityController> logger)
//        //{
//        //    ServiceManager = serviceManager;
//        //    this.logger = logger;
//        //}

//        // GET: api/Activity/Get
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.ActivityService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/Activity/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.ActivityService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // GET Activity/GetDDL
//        [Authorize]
//        [HttpGet("GetDDL")]
//        public async Task<IActionResult> GetDDL()
//        {
//            var result = await ServiceManager.ActivityService.GetDDL();
            
//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }   

//        // GET api/Activity/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.ActivityService.GetById(Id);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

            

//        // POST api/Activity
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] ActivityCreateDto entity)
//        {

//            ActivityCreateValidator validator = new ActivityCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ActivityService.Add(entity);

                        
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/Activity/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] ActivityUpdateDto entity)
//        {

//            ActivityUpdateValidator validator = new ActivityUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if(!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x=> x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));
                
//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.ActivityService.Update(entity);
            
//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/Activity/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.ActivityService.Remove(Id);
                        
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
