using Agricultural.Application.Common;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.WebApi.Controllers.BaseApi;

using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalSectionsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.AdditionalSectionsService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }
        [HttpGet("GetlistMainWithAdd")]
        public async Task<IActionResult> GetlistMainWithAdd()
        {
            var result = await ServiceManager.AdditionalSectionsService.GetlistMainWithAdd();

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
            var result = await ServiceManager.AdditionalSectionsService.GetAll(dtRequest);

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
            var result = await ServiceManager.AdditionalSectionsService.GetDDL();

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
        [HttpGet("GetByMianClassFication/{MainClassfication}")]
        public async Task<IActionResult> GetByMianClassFication(int MainClassfication)
        {
            var res = await ServiceManager.AdditionalSectionsService.Find(a => a.MainClassificationId == MainClassfication);
            if (res.Succeeded)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await ServiceManager.AdditionalSectionsService.GetById(Id);

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
        public async Task<IActionResult> Post([FromBody] AdditionalSectionsDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.AdditionalSectionsService.Add(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AdditionalSectionsDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.AdditionalSectionsService.Update(entity);


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
            var result = await ServiceManager.AdditionalSectionsService.Remove(Id);

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
