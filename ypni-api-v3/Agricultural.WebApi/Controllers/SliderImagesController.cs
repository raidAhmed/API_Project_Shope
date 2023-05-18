
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.DTOs.SliderImages;

using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.Application.Interfaces.Common;
using Agricultural.WebApi.ViewModel;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderImagesController : BaseApiController
    {

        private readonly IUploadFileService _uploadFileService;
        private readonly ICustomConventer _customConventer;

        public SliderImagesController(ICustomConventer customConventer, IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
            _customConventer = customConventer;
            

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SliderImagesService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // POST: api/SliderImages/GetDt
    
        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.SliderImagesService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // GET SliderImages/GetDDL
        
        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.SliderImagesService.GetDDL();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        // GET api/SliderImages/5
       
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {


            if (Id == 0)
            {
                var resultSlider = await ServiceManager.SliderService.GetAll();

                if (resultSlider.Data!=null)
                {
                    var res = resultSlider.Data.Where(x => x.ServiceProviderId == null && x.Active==true);

                    var result = await ServiceManager.SliderImagesService.Find(x => x.SliderId == res.First().Id);
                    if (result.Succeeded)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result.Status);
                    }







                }
                return BadRequest(resultSlider.Status);



            }
            else
            {
                var resultSlider = await ServiceManager.SliderService.Find(x => x.ServiceProviderId == Id);


                if (resultSlider.Data.Any())
                {
                    Id = resultSlider.Data.First().Id;
                    var result = await ServiceManager.SliderImagesService.Find(x => x.SliderId == Id);

                    if (result.Succeeded)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result.Status);
                    }

                }

                return Ok(resultSlider);
            }


        }



        // POST api/SliderImages

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] sliderimagevm entity)
        {
            

            if (entity == null) return BadRequest("null"); 
            try
            {
                var json = _customConventer.DecodeJson<SliderImagesVM>(entity.sliderimageVm);
                var oldimg = "";
                var imgname = "";
               // if (entity.File != null)
                if (entity.imageUrl != null)
                {

                    imgname = entity.imageUrl;
                        //_uploadFileService.UploadFile(entity.File, "SliderImagesService");

                }




                //entity.ImageUrl = imgname;
                var obj = new SliderImagesDto();

                oldimg = json.ImageUrl;
                if (entity.imageUrl != null)
                {
                     obj = new SliderImagesDto
                    {
                        Active = true,
                        Details = json.Details,
                        Id = json.Id,
                        ImageUrl = imgname,
                        SliderId = json.SliderId,
                        Title = json.Title,
                        Url = imgname,
                      

                    };
                }
                else
                {
                     obj = new SliderImagesDto
                    {
                         Active = true,
                         Details = json.Details,
                         Id = json.Id,
                        
                         SliderId = json.SliderId,
                         Title = json.Title,
                         Url = oldimg,
                         ImageUrl = oldimg,
                     

                    };

                }
                var result = await ServiceManager.SliderImagesService.Add(obj);


                if (result.Succeeded)
                {
                    if (entity.imageUrl != null)
                    {
                  //      _uploadFileService.DeleteImageFile(oldimg, "SliderImagesService");
                    }
                        return Ok(result);
                }
                else
                {
             //       _uploadFileService.DeleteImageFile(imgname, "SliderImagesService");
                    return BadRequest(result.Status);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  
        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromForm] sliderimagevm entity)
        {

            if (entity == null) return BadRequest("null");
            var oldimg = "";
            var imgname = "";
           var json = _customConventer.DecodeJson<SliderImagesVM>(entity.sliderimageVm);

            //if (entity.File != null)
            if (entity.imageUrl != null)
            {

                imgname =entity.imageUrl;
                    //_uploadFileService.UploadFile(entity.File, "SliderImagesService");

            }




            //entity.ImageUrl = imgname;
            var obj = new SliderImagesDto();

            oldimg = entity.imageUrl;
            //if (entity.File != null)
            if (entity.imageUrl != null)
            {
                obj = new SliderImagesDto
                {
                    Active = true,
                    Details = json.Details,
                    Id = json.Id,
                    ImageUrl = imgname,
                    SliderId = json.SliderId,
                    Title = json.Title,
                    Url = imgname,


                };
            }
            else
            {
                obj = new SliderImagesDto
                {
                    Active = true,
                    Details = json.Details,
                    Id = json.Id,
                    SliderId = json.SliderId,
                    Title = json.Title,
                    Url = json.ImageUrl,
                    ImageUrl = json.ImageUrl,


                };

            }

            var result = await ServiceManager.SliderImagesService.Update(obj);


            if (result.Succeeded)
            {
                //if (entity.File != null)
                if (entity.imageUrl != null)
                {
                  //  _uploadFileService.DeleteImageFile(oldimg, "SliderImagesService");
                }
                return Ok(result);
            }
            else
            {
             
                  //  _uploadFileService.DeleteImageFile(imgname, "SliderImagesService");
               
                return BadRequest(result.Status);
            }
        }

       
        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.SliderImagesService.Remove(Id);

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
