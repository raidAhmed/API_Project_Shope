
   
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.DTOs.ActivityType;

using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.WebApi.ViewModel;
using Agricultural.Application.Interfaces.Common;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : BaseApiController
    {
        private readonly ICustomConventer _customConventer;

        public ActivityTypeController(ICustomConventer customConventer)
        {
            _customConventer = customConventer;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.ActivityTypeService.GetAll();

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
            var result = await ServiceManager.ActivityTypeService.GetAll(dtRequest);

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
            var result = await ServiceManager.ActivityTypeService.GetDDL();

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
            var result = await ServiceManager.ActivityTypeService.GetById(Id);

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
        public async Task<IActionResult> Post([FromBody] ActivityTypeDto entity)
        {
            

            if (entity == null) return BadRequest("null");
            try
            {

                var result = await ServiceManager.ActivityTypeService.Add(entity);


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

        [HttpPost("Postt")]
        public async Task<IActionResult> Postt([FromForm] Image entity)
        {
            try
            {
                var json = _customConventer.DecodeJson<Imagedetiles>(entity.Imagedetiles);
                Console.WriteLine($"Imagedetiles typserverBrovidere  {json.serverBrovider}");
                var img = ServiceManager.UploadFileService.UploadFileProduct(entity.File, json.Type, json.serverBrovider);
                var imgg = new Imagedetiles();
                if (img != null)
                {
                    imgg.Type = json.Type;
                    imgg.serverBrovider = img.ToString();
                }
                if (img == "NotImage")
                {
                    return BadRequest("  png or jpg íÌÈ Çä Êßæä ÕíÛÉ ÇáÕæÑ ãä äæÚ  ");
                    //  return BadRequest("the must upload image jpg or png");

                }
                else if (img == "over")
                {
                    return BadRequest("íÌÈ Çä Êßæä ÍÌã ÇáÕæÑÉ 2 ãíÌÇ 111111111 Çæ ÇÞá");
                    // return BadRequest("the Image must be or less than 2mb");

                }
                else if (img == "err")
                {
                    return BadRequest("íæÌÏ ÎØÇÁ Ýí ÇáÕæÑ ÇÚÏ ÑÝÚ ÇáÕæÑ ãä ÌÏíÏ");

                }
                else
                {
                    Console.WriteLine($"imageName is ==============================>   {entity.File.FileName}  ");
                    Console.WriteLine($"imag is ==============================>   {img}  ");
                    //   Console.WriteLine($"name is ==============================>   {entity.name}  ");
                    return Ok(imgg);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"errorr is ==============================>   {ex.Message}  ");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] ActivityTypeDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.ActivityTypeService.Update(entity);


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
            var result = await ServiceManager.ActivityTypeService.Remove(Id);

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
