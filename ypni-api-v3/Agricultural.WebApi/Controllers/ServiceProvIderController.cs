
//////////////////////////////////////////////////////////
///                 Ibrahim AL-afif                    ///
///                 ib2050a@gmail.com                 ///
///                 +967 777 384 772                 ///
///generated ServiceProvIderController.cs ///
//////////////////////////////////////////////////////
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;

using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.WebApi.ViewModel;
using Agricultural.Application.Interfaces.Common;
using Microsoft.AspNetCore.Identity;
using Agricultural.Domain.Entity;

namespace Agricultural.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProvIderController : BaseApiController
    {
        private readonly ICustomConventer _customConventer;
        private readonly IUploadFileService _uploadFileService;
        private readonly UserManager<User> _userManager;

        public ServiceProvIderController(ICustomConventer customConventer, UserManager<User> userManager, IUploadFileService uploadFileService)
        {
            _customConventer = customConventer;
            _uploadFileService = uploadFileService;
            _userManager = userManager;

        }
      
   

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.ServiceProviderService.GetAll();

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
            var result = await ServiceManager.ServiceProviderService.GetAll(dtRequest);

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
            var result = await ServiceManager.ServiceProviderService.GetDDL();

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
            var result = await ServiceManager.ServiceProviderService.Find(x=>x.UserId==Id); 

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpGet("GetByIdd/{Id}")]
        public async Task<IActionResult> GetByIdd(int Id)
        {
            var result = await ServiceManager.ServiceProviderService.GetById(Id);

            if (result.Succeeded)
            {
                //var r = new Result<ServiceProviderQueryDto>
                //{
                //    Data = result.Data.First(),
                //    Status = result.Status,
                //    Succeeded = result.Succeeded,
                //};
                return Ok(result);

                // return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        // POST api/ActivityType

        [HttpPost("Post")]
        public async Task<IActionResult> Post(ServerProviderVmodel entity) 
        {

            if (entity == null) return BadRequest("null");

            ServiceProviderDto obj = new ServiceProviderDto();

            obj.Id = entity.id; 
            obj.TradeName = entity.tradeName; 
            obj.Logo = entity.logo; 
            obj.ActivityTypeId = entity.activityTypeId; 
            obj.ServiceTypeId = entity.serviceTypeId; 
            obj.PhoneNumber = entity.phoneNumber; 
            obj.NatId = entity.natId; 
            obj.Email = entity.email; 
            obj.UserId = entity.userId; 
            obj.Logo = "";  
            obj.Type = entity.type; 
            obj.ViewPlace = entity.viewPlace; 
            obj.Description = entity.description; 
             var result = await ServiceManager.ServiceProviderService.Add(obj); 


            if (result.Succeeded)
            {
                var user = await ServiceManager.ServiceProviderService.UpdateUserStatus(entity.userId);
                user.Data.Status = !user.Data.Status;
                await ServiceManager.UserService.Update(user.Data);

                var ServiceProvider = await _userManager.FindByIdAsync(result.Data.UserId);
                await _userManager.AddToRoleAsync(ServiceProvider, "ServiceProvider");

                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }



        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromForm] ServerProviderViewModel entity)
        {
            var img = "";
            var oldimg = "";

            if (entity == null) return BadRequest("null");
            var json = _customConventer.DecodeJson<ServerProviderVmodel>(entity.serverProviderVm);

            // if (entity.File != null)
            if (entity.imageUrl!= null)
            {

                img = entity.imageUrl;
                    
                    //_uploadFileService.UploadFile(entity.File, "ServerProvider");

            }

            var obj = new ServiceProviderDto();
            oldimg = json.logo;

           // if (entity.File != null)
            if (entity.imageUrl != null)
            {
                obj = new ServiceProviderDto
                {
                    Id = json.id,
                    PhoneNumber = json.phoneNumber,
                    ActivityTypeId = json.activityTypeId,
                    Description = json.description,
                    Email = json.email,
                    Logo = img,
                    NatId = json.natId,
                    ServiceTypeId = json.serviceTypeId,
                    TradeName = json.tradeName,
                    Type = json.type,
                    UserId = json.userId,
                    ViewPlace = json.viewPlace,



                };

            }
            else
            {
                obj = new ServiceProviderDto
                {
                    Id = json.id,
                    PhoneNumber = json.phoneNumber,
                    ActivityTypeId = json.activityTypeId,
                    Description = json.description,
                    Email = json.email,
                    Logo = oldimg,
                    NatId = json.natId,
                    ServiceTypeId = json.serviceTypeId,
                    TradeName = json.tradeName,
                    Type = json.type,
                    UserId = json.userId,
                    ViewPlace = json.viewPlace,



                };

            }


            var result = await ServiceManager.ServiceProviderService.Update(obj);


            if (result.Succeeded)
            {
              //  if (entity.File != null)
                if (entity.imageUrl != null)
                {

                //    _uploadFileService.DeleteImageFile(oldimg, "ServerProvider");

                }
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
            var result = await ServiceManager.ServiceProviderService.Remove(Id);

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
