
   
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.DTOs.WorkingHours;

using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.WebApi.ViewModel;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.DTOs.WorkinPoeriods;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingPoeriodsController : BaseApiController
    {
        private readonly ICustomConventer _customConventer;

        public WorkingPoeriodsController(ICustomConventer customConventer)
        {
            _customConventer = customConventer;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.WorkinPoeriodsService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // POST: api/WorkingHours/GetDt
    
        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.WorkinPoeriodsService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // GET WorkingHours/GetDDL
        


        // GET api/WorkingHours/5
       
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await ServiceManager.WorkinPoeriodsService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }



        // POST api/WorkingHours
       
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] WorkinPoeriodsDto entity)
        {
            

            if (entity == null) return BadRequest("null");
            try
            {

                var result = await ServiceManager.WorkinPoeriodsService.Add(entity);


                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Status);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] WorkinPoeriodsDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.WorkinPoeriodsService.Update(entity);


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
            var result = await ServiceManager.WorkinPoeriodsService.Remove(Id);

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
