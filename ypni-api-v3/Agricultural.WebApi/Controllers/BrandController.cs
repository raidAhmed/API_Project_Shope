using Agricultural.Application.Common;

using Agricultural.Application.DTOs.Brand;
using Agricultural.WebApi.Controllers.BaseApi;

using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.BrandService.GetAll();

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
            var result = await ServiceManager.BrandService.GetAll(dtRequest);

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
            var result = await ServiceManager.BrandService.GetDDL();

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
            var result = await ServiceManager.BrandService.GetById(Id);

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
        public async Task<IActionResult> Post([FromBody] BrandDto entity)
        {
            var imgname = "";

            if (entity == null) return BadRequest("null");


            if (entity.ImageUrl != null)
            {
                imgname = entity.ImageUrl;
                // img = _uploadFileService.UploadFile(entity.imageUrl, "SpecialSection");

            }
            entity.ManufactureCompanyId = 1;
            entity.Active = true;

            var obj = new BrandDto();
            if (entity.ImageUrl != null)
            {
                obj = new BrandDto
                {
                    Id = entity.Id,
                    ImageUrl = entity.ImageUrl,
                    Name = entity.Name,
                    Active = entity.Active,
                    ManufactureCompanyId = entity.ManufactureCompanyId,

                };
            }
            var result = await ServiceManager.BrandService.Add(entity);


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
        public async Task<IActionResult> Put([FromBody] BrandDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.BrandService.Update(entity);


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
            var result = await ServiceManager.BrandService.Remove(Id);

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
