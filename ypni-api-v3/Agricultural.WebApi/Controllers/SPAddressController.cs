using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_Address;
using Agricultural.Domain.Entity;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPAddressController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SP_AddressService.GetAll();

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
            var result = await ServiceManager.SP_AddressService.GetAll(dtRequest);

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
            var result = await ServiceManager.SP_AddressService.GetDDL();

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
        public async Task<IActionResult> GetById(string Id)
        {
            var result = await ServiceManager.SP_AddressService.FindByServicePro(x=>x.UserId==Id); 

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
        public async Task<IActionResult> GetByServerProviderId(string userId)
        {

            // var result = await ServiceManager.SP_AddressService.GetByServiceId(serverProviderId);
            var result = await ServiceManager.SP_AddressService.FindByServicePro(s => s.UserId == userId);


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
        public async Task<IActionResult> Post([FromBody] SPAddressVm entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {

                SP_AddressDto obj = new SP_AddressDto()
                {
                    Id = entity.Id,
                    DirectorateId = entity.DirectorateId,
                    UserId = entity.UserId,
                    Street = entity.Street,
                    Description = entity.Description,
                    State = entity.State,
                     
                };


                var result = await ServiceManager.SP_AddressService.Add(obj);


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
        public async Task<IActionResult> Put([FromBody] SPAddressVm entity)
        {

            if (entity == null) return BadRequest("null");

            SP_AddressDto obj = new SP_AddressDto()
            {
                Id = entity.Id,
                DirectorateId = entity.DirectorateId,
                UserId = entity.UserId,
                Street = entity.Street,
                Description = entity.Description,
                State = entity.State,


            };



            var result = await ServiceManager.SP_AddressService.Update(obj);


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
            var result = await ServiceManager.SP_AddressService.Remove(Id);

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
