using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPAdditionalSectionsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SP_AdditionalSectionsService.GetAll();

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
            var result = await ServiceManager.SP_AdditionalSectionsService.GetAll(dtRequest);

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
            var result = await ServiceManager.SP_AdditionalSectionsService.GetDDL();

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
            var result = await ServiceManager.SP_AdditionalSectionsService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }
        [HttpGet("GetByIdSPandmainclassficationInfo/{Id}")]
        public async Task<IActionResult> GetByIdSPandmainclassficationInfo(int Id)
        {
            var result = await ServiceManager.SP_AdditionalSectionsService.GetByIdSPInfo(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }    
        
        [HttpGet("GetByIdSPandmainclassficationAll")]
        public async Task<IActionResult> GetByIdSPandmainclassficationAll()
        {
            var result = await ServiceManager.SP_AdditionalSectionsService.GetByIdSPInfoAll();

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
        public async Task<IActionResult> Post([FromBody] List<SP_AdditionalSectionsDtoApi> entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {
            
                var result = await ServiceManager.SP_AdditionalSectionsService.Addlistt(entity);


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


        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromBody] SP_AdditionalSectionsDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.SP_AdditionalSectionsService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.SP_AdditionalSectionsService.Remove(Id);

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
