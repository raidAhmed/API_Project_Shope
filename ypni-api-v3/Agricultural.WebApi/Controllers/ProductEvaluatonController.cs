using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProductEvaluaton;
using Agricultural.Application.DTOs.ProviderEvaluation;
using Agricultural.Application.Services;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEvaluatonController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.ProviderEvaluationService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // POST: api/ActivityType/GetDt

        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.ProviderEvaluationService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // GET ActivityType/GetDDL

        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.ProviderEvaluationService.GetDDL();

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
            var result = await ServiceManager.ProviderEvaluationService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }



        // POST api/ActivityType
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] ProductEvaluatonDto entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {
                var ressu = await ServiceManager.ProductEvaluatonService.Find(x => x.UserId == entity.UserId && x.ProductId == entity.ProductId);

                if (ressu.Data != null)
                {
                    entity.Id = ressu.Data.FirstOrDefault().Id;
                    var result = await ServiceManager.ProductEvaluatonService.Update(entity);


                    if (result.Succeeded)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result.Status);
                    }
                }
                else
                {
                    var result = await ServiceManager.ProductEvaluatonService.Add(entity);


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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromBody] ProductEvaluatonDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.ProductEvaluatonService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.ProductEvaluatonService.Remove(Id);

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
