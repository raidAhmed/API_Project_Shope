
//////////////////////////////////////////////////////////
///                 Ibrahim AL-afif                    ///
///                 ib2050a@gmail.com                 ///
///                 +967 777 384 772                 ///
///generated ProductColorController.cs ///
//////////////////////////////////////////////////////
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Colors;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.Product_ColorsService.GetAll();

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
            var result = await ServiceManager.Product_ColorsService.GetAll(dtRequest);

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
            var result = await ServiceManager.Product_ColorsService.GetDDL();

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
            var result = await ServiceManager.Product_ColorsService.GetById(Id);

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
        public async Task<IActionResult> Post([FromBody] Product_ColorsDto entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {

                var result = await ServiceManager.Product_ColorsService.Add(entity);


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


        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] Product_ColorsDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.Product_ColorsService.Update(entity);


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
            var result = await ServiceManager.Product_ColorsService.Remove(Id);

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
