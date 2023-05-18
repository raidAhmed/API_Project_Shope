using Agricultural.Application.Common;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPMainClassificationController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SP_MainClassificationService.GetAll();

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
            var result = await ServiceManager.SP_MainClassificationService.GetAll(dtRequest);

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
            var result = await ServiceManager.SP_MainClassificationService.GetDDL();

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
            var result = await ServiceManager.SP_MainClassificationService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpGet("GetByServerProviderId/{serverProviderId}")]
        public async Task<IActionResult> GetByServerProviderId(int serverProviderId)
        {

             var result = await ServiceManager.SP_MainClassificationService.Find(s=>s.ServiceProviderId==serverProviderId);
            var Status = new Message();
            var mainClass= new List<MainClassificationQueryDto>();
            bool Succeeded=false;

            if (result.Succeeded)
            {
             foreach (var item in result.Data)
                {
                    var res =await ServiceManager.MainClassificationService.GetById(item.MainClassificationId.Value);
                    if (res.Succeeded)
                    {
                        mainClass.Add(res.Data);
                        Status.message = res.Status.message;
                        Status.code = res.Status.code;
                        Succeeded = res.Succeeded;
                    }
                    else
                    {
                        Status.message = res.Status.message;
                        Status.code = res.Status.code;
                        Succeeded = res.Succeeded;

                    }
                  

                }
                var obj = new Result<List<MainClassificationQueryDto>>
                {
                    Data = mainClass,
                    Status = Status,
                    Succeeded = Succeeded
                };
                if (Succeeded)
                {
                    return Ok(obj);

                }
                else
                {
                    return BadRequest(obj);
                }

            }
            else
            {
                return BadRequest(result);
            }
            
        }

        // POST api/ActivityType

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] List<SP_MainClassificationDtoApi>  entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {
             

                    var result = await ServiceManager.SP_MainClassificationService.Addlistt(entity);
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
        public async Task<IActionResult> Put([FromBody] SP_MainClassificationDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.SP_MainClassificationService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.SP_MainClassificationService.Remove(Id);

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
