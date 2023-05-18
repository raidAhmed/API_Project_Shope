using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.Interfaces.Common;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.ViewModel;
using Agricultural.WebMvc.Controllers.BaseMvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Agricultural.WebApi.ViewModel.SpecialSectionVm;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialSectionsController : BaseApiController
    {
        private readonly ICustomConventer _customConventer;
        private readonly IUploadFileService _uploadFileService;

        public SpecialSectionsController(ICustomConventer customConventer, IUploadFileService uploadFileService)
        {
            _customConventer = customConventer;
            _uploadFileService = uploadFileService;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SpecialSectionsService.GetAll();

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
            var result = await ServiceManager.SpecialSectionsService.GetAll(dtRequest);

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
            var result = await ServiceManager.SpecialSectionsService.GetDDL();

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

        [HttpGet("GetById")] 
        public async Task<IActionResult> GetById( int Id,int additionalsection)
        {

            var result = await ServiceManager.SpecialSectionsService.Find(x=>x.ServiceProviderId==Id&&x.AdditionalSectionsId== additionalsection);
            var result1 = await ServiceManager.SpecialSectionsService.GetById(Id);

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
        public async Task<IActionResult> Post([FromForm] SpecialSectionViewModel entity)
        {

            var imgname = "";
            if (entity == null) return BadRequest("null");

            try
            {
                var json = _customConventer.DecodeJson<SpecialSectionVm>(entity.specialsectionVm);


                if (entity.imageUrl != null)
                {
                    imgname = entity.imageUrl;
                   // img = _uploadFileService.UploadFile(entity.imageUrl, "SpecialSection");



                }
                json.ParnetSectionId = null;
                var obj = new SpecialSectionsDto();
                if (entity.imageUrl != null)
                {
                    obj = new SpecialSectionsDto
                    {
                        Id = json.Id,
                        MainClassificationId=json.MainClassificationId,
                         
                        AdditionalSectionsId = json.AdditionalSectionsId,
                        ServiceProviderId = json.ServiceProviderId,
                        SpecialSectionName = json.SpecialSectionName,
                        ImageUrl = imgname,
                        Active = json.Active,
                        ParnetSectionId = json.ParnetSectionId,
                        Rank = json.Rank,
                        
                    }; 
                }

                var result = await ServiceManager.SpecialSectionsService.Add(obj);
                 

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
        public async Task<IActionResult> Put([FromForm] SpecialSectionViewModel entity)
        {


            var imgname = "";
            var oldimg = "";
            if (entity == null) return BadRequest("null");

            try
            {
                var json = _customConventer.DecodeJson<SpecialSectionVm>(entity.specialsectionVm);


                if (entity.imageUrl != null)
                {
                    imgname = entity.imageUrl;
                    //img = _uploadFileService.UploadFile(entity.File, "SpecialSection");



                }
                var obj = new SpecialSectionsDto();
                oldimg = json.ImageUrl; 
                if (entity.imageUrl != null)
                {
                    obj = new SpecialSectionsDto
                    {
                        Id = json.Id,
                        MainClassificationId = json.MainClassificationId,

                        AdditionalSectionsId = json.AdditionalSectionsId,
                        ServiceProviderId = json.ServiceProviderId,
                        SpecialSectionName = json.SpecialSectionName,
                        ImageUrl = imgname,
                        Active = json.Active,
                        ParnetSectionId = null,
                        Rank = json.Rank,
                    };
                }
                else
                {
                    obj = new SpecialSectionsDto
                    {
                        Id = json.Id,
                        MainClassificationId = json.MainClassificationId,

                        AdditionalSectionsId = json.AdditionalSectionsId,
                        ServiceProviderId = json.ServiceProviderId,
                        SpecialSectionName = json.SpecialSectionName,
                        ImageUrl = oldimg,
                        Active = json.Active,
                        ParnetSectionId = null,
                        Rank = json.Rank,
                    };

                }

                



                var result = await ServiceManager.SpecialSectionsService.Update(obj);


                if (result.Succeeded)
                {
                    if (entity.imageUrl != null)
                    {

                      //  _uploadFileService.DeleteImageFile(oldimg, "SpecialSection");

                    }

                    return Ok(result);
                }
                else
                {
                    if (entity.imageUrl != null)
                    {

                    //    _uploadFileService.DeleteImageFile(imgname, "SpecialSection");

                    }

                    return BadRequest(result.Status);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.SpecialSectionsService.Remove(Id);

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
