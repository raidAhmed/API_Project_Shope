using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantToParty;
using Agricultural.Infrastructure.Services;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Agricultural.WebApi.ViewModel.ChatVm;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainantToPartyController : BaseApiController
    {
        private readonly ICustomConventer _customConventer;
        private readonly IUploadFileService _uploadFileService;

        public ComplainantToPartyController(ICustomConventer customConventer, IUploadFileService uploadFileService)
        {
            _customConventer = customConventer;
            _uploadFileService = uploadFileService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.ComplainantToPartyService.GetAll();

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
            var result = await ServiceManager.ComplainantToPartyService.GetAll(dtRequest);

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
            var result = await ServiceManager.ComplainantToPartyService.GetDDL();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }
        [HttpGet("GetAlll")]
        public async Task<IActionResult> GetAlll(string id)
        {
            var result = await ServiceManager.ComplainantToPartyService.GetAlll(id);

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
        public async Task<IActionResult> GetById(string SenderId,string ReciverId)
        {
            var result = await ServiceManager.ComplainantToPartyService.Find(x => x.SenderId == SenderId && x.ReciverId == ReciverId|| x.SenderId == ReciverId && x.ReciverId == SenderId); 

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
        public async Task<IActionResult> Post([FromForm] ChatModel entity)
        {


            var img = "";
          
            if (entity == null) return BadRequest("null");
            var json = _customConventer.DecodeJson<ChatVm>(entity.chatVm);

           // if (entity.File != null)
            if (entity.imageUrl != null)
            {
                img = entity.imageUrl;
                //img = _uploadFileService.UploadFileProduct(entity.File, "Chat", json.senderId);


            }


            var obj = new ComplainantToPartyDto();


            if (entity.imageUrl != null)
            {

                obj = new ComplainantToPartyDto
                {
                    Id = json.id,
                    ReciverId =json.reciverId,
                    SenderId = json.senderId,
                    Topic = json.topic,
                    TypeofMesseage = img,
                    requestState = false,
                    Active = true,
                    CreatedAt= DateTime.Now,
                    ServiceType = json.serviceType,
                    
                  
                    
                };
            }
            else
            {
                obj = new ComplainantToPartyDto
                {
                    Id = json.id,
                    ReciverId = json.reciverId,
                    SenderId = json.senderId,
                    Topic = json.topic,
                    TypeofMesseage = "Ms",
                    requestState = false,
                    Active = true,
                    CreatedAt = DateTime.Now,
                    ServiceType = json.serviceType,


                };


            }
            
            var result = await ServiceManager.ComplainantToPartyService.Add(obj);


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
        public async Task<IActionResult> Put(string SenderId,string ReciverId)
        {

            //if (entity == null) return BadRequest("null");

            var ss = await ServiceManager.ComplainantToPartyService.Find(x => x.SenderId == SenderId && x.ReciverId == ReciverId&&x.requestState==false);
            if(ss.Data!=null)
            foreach (var item in ss.Data)
            {
                    item.requestState = true;
                    var resullt = await ServiceManager.ComplainantToPartyService.Update(item);



                }


         


            if (ss.Succeeded)
            {
                return Ok(ss);
            }
            else
            {
                return BadRequest(ss.Status);
            }
        }



        //public async Task<IActionResult> getdata(string Reciver, string Sender, int FalterChatsId)
        //{
        //    var json = new List<dynamic>();
        //    var message = await GetMessage(Reciver, Sender, FalterChatsId);
        //    foreach (var i in message)
        //    {
        //        var dect = new Dictionary<string, dynamic>();
        //        if (i != null)
        //        {
        //            dect.Add("id", i.Id);
        //            dect.Add("topic", i.Topic);
        //            dect.Add("typeofMesseage", i.TypeofMesseage);
        //            dect.Add("senderId", i.SenderId);
        //            dect.Add("reciverId", i.ReciverId);
        //            dect.Add("requestState", i.requestState);
        //        }
        //        json.Add(dect);
        //    }
        //    return Ok(json);
        //}
        //public async Task<ComplainantToPartyDDlLViewModels> GetChats(int ServiceType)
        //{
        //    var ComplainantToPartyDDlLViewModels = new ComplainantToPartyDDlLViewModels();
        //    var ComplainantToPartyChatsDto = new List<ComplainantToPartyChatsDto>();
        //    var Service = new ServiceProviderQueryDto();
        //    List<ComplainantToPartyQueryDto> Messeages = new List<ComplainantToPartyQueryDto>();
        //    var ItemMesseages = await ServiceManager.ComplainantToPartyService.Find(x => (x.ServiceType == ServiceType) && (x.SenderId == UserId || x.ReciverId == UserId));
        //    Messeages = ItemMesseages.Data.OrderByDescending(x => x.Id).ToList();
        //    foreach (var i in Messeages)
        //    {
        //        var idd = i.SenderId;
        //        if (i.SenderId == UserId)
        //        {
        //            idd = i.ReciverId;
        //        }
        //        var user = await ServiceManager.UserService.GetById(idd);
        //        if (user.Data.Status == false)
        //        {
        //            Service.UserId = idd;
        //            Service.TradeName = user.Data.UserName;
        //            Service.Logo = "/Upload/Users/" + user.Data.Image;
        //        }
        //        else
        //        {
        //            var objj = await ServiceManager.ServiceProviderService.Find(x => x.UserId == idd);
        //            var obj = objj.Data.FirstOrDefault();
        //            Service = obj;
        //            Service.Logo = "/Upload/ServiceProvider/" + Service.Logo;
        //        }
        //        var messagesall = Messeages.Where(x => (x.ReciverId == UserId && x.SenderId == idd) && x.requestState == false);
        //        var count = messagesall.Count();
        //        if (ComplainantToPartyChatsDto.Find(x => x.UserId == user.Data.Id) == null && Service != null)
        //        {
        //            ComplainantToPartyChatsDto.Add(new ComplainantToPartyChatsDto
        //            {
        //                UserId = idd,
        //                Logo = Service.Logo,
        //                Topic = i.Topic,
        //                count = count,
        //                TradeName = Service.TradeName,
        //                Description = Service.Description,
        //            });
        //        }
        //    }
        //    ComplainantToPartyDDlLViewModels.ComplainantToPartyChatsDto = ComplainantToPartyChatsDto;
        //    return ComplainantToPartyDDlLViewModels;
        //}

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.ComplainantToPartyService.Remove(Id);

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
