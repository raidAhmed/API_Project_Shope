using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.City;
using Agricultural.Application.DTOs.User_Bank;
using Agricultural.Application.DTOs.Banks;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseApiController 
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.BanksService.GetAll(); 

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
            var result = await ServiceManager.BanksService.GetAll(dtRequest);

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
            var result = await ServiceManager.BanksService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] BanksDto entity) 
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.BanksService.Add(entity);


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
