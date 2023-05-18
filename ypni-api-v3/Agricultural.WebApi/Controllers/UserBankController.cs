using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.City;
using Agricultural.Application.DTOs.User_Bank;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBankController : BaseApiController
    {
        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.User_BankService.GetAll();

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
            var result = await ServiceManager.User_BankService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var result = await ServiceManager.User_BankService.Find(x=>x.UserId==Id);

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
        public async Task<IActionResult> Post([FromBody] User_BankDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result2 = await ServiceManager.User_BankService.Find(x=>x.UserId==entity.UserId&&x.BanksId==entity.BanksId);
            if (result2.Data.Count()!=0)
            {
                //entity.Id = result2.Data.FirstOrDefault().Id;

                //var result = await ServiceManager.User_BankService.Update(entity);


                //if (result2.Succeeded)
                //{
                  //  return Ok(result2);
                //}
                //else
               // {
                    return BadRequest(result2.Status);
             //   }
            }
            else
            {
                var result = await ServiceManager.User_BankService.Add(entity);


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


        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromBody] User_BankDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.User_BankService.Update(entity);


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
            var result = await ServiceManager.User_BankService.Remove(Id);

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
