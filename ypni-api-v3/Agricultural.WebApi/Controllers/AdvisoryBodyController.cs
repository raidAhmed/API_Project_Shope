
////////////////////////////////////////////////////////////
/////                 Ibrahim AL-afif                    ///
/////                 ib2050a@gmail.com                 ///
/////                 +967 777 384 772                 ///
/////generated AdvisoryBodyController.cs ///
////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Agricultural.WebApi.Controllers.BaseApi;
//using Agricultural.Application.DTOs.AdvisoryBody;
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
//    public class AdvisoryBodyController : BaseApiController
//    {
        
//        [Authorize]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var result = await ServiceManager.AdvisoryBodyService.GetAll();

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // POST: api/AdvisoryBody/GetDt
//        [Authorize]
//        [HttpPost("GetDt")]
//        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
//        {
//            var result = await ServiceManager.AdvisoryBodyService.GetAll(dtRequest);

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }

//        }

//        // GET AdvisoryBody/GetDDL
//        [Authorize]
//        [HttpGet("GetDDL")]
//        public async Task<IActionResult> GetDDL()
//        {
//            var result = await ServiceManager.AdvisoryBodyService.GetDDL();

//            if (result.Succeeded)
//            {
//                return Ok(result.Data);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // GET api/AdvisoryBody/5
//        [Authorize]
//        [HttpGet("GetById/{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await ServiceManager.AdvisoryBodyService.GetById(Id);

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }



//        // POST api/AdvisoryBody
//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] AdvisoryBodyCreateDto entity)
//        {

//            AdvisoryBodyCreateValidator validator = new AdvisoryBodyCreateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if (!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x => x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));

//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.AdvisoryBodyService.Add(entity);


//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // PUT api/AdvisoryBody/5
//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] AdvisoryBodyUpdateDto entity)
//        {

//            AdvisoryBodyUpdateValidator validator = new AdvisoryBodyUpdateValidator();

//            ValidationResult validationResult = validator.Validate(entity);

//            if (!validationResult.IsValid)
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                validationResult.Errors.Select(x => x.ErrorMessage).ToList().ForEach(x => stringBuilder.AppendLine(x));

//                return BadRequest(Result.Fail(stringBuilder.ToString(), 500));
//            }


//            var result = await ServiceManager.AdvisoryBodyService.Update(entity);

//            if (result.Succeeded)
//            {
//                return Ok(result);
//            }
//            else
//            {
//                return BadRequest(result.Status);
//            }
//        }

//        // DELETE api/AdvisoryBody/5
//        [Authorize]
//        [HttpDelete("Delete/{Id}")]
//        public async Task<IActionResult> Delete(int Id)
//        {
//            var result = await ServiceManager.AdvisoryBodyService.Remove(Id);

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
