using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;

using Agricultural.Application.Wrapper;

using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.Application.DTOs.BusinessCommercial;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCommercialController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.BusinessCommercialService.GetAll();

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
            var result = await ServiceManager.BusinessCommercialService.GetAll(dtRequest);

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
            var result = await ServiceManager.BusinessCommercialService.GetDDL();

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
            var result = await ServiceManager.BusinessCommercialService.Find(x=>x.ServiceProviderId==Id);

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BusinessCommercialDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.BusinessCommercialService.Add(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromBody] BusinessCommercialDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.BusinessCommercialService.Update(entity);


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
            var result = await ServiceManager.BusinessCommercialService.Remove(Id);

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
