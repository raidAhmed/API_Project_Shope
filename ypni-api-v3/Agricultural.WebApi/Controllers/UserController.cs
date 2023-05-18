
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.DTOs.User;

using Agricultural.Application.Common;
using static Agricultural.WebApi.ViewModel.UserVm;
using Agricultural.Application.Interfaces.Common;
using Agricultural.WebApi.ViewModel;
using Microsoft.AspNetCore.Identity;
using Agricultural.Domain.Entity;
using AutoMapper;
using Agricultural.Application.Auth;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ICustomConventer _customConventer;
        private readonly IUploadFileService _uploadFileService;
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenManager _jwtTokenManager;
        public UserController(ICustomConventer customConventer, IJwtTokenManager jwtTokenManager, IUploadFileService uploadFileService, UserManager<User> userManager, IMapper mapper)
        {
            _customConventer = customConventer;
            _uploadFileService = uploadFileService;
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenManager = jwtTokenManager;
        }
        //[Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await ServiceManager.UserService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // POST: api/User/GetDt
        [Authorize]
        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt(DtRequest dtRequest)
        {
            var result = await ServiceManager.UserService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        [Authorize]
        // GET User/GetDDL
        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.UserService.GetDDL();
            
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }   
        
        // GET api/User/5
      //  [Authorize]
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var result = await ServiceManager.UserService.GetById(Id);
            
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

            

        // POST api/User
       // [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserVm entity) 
        { 
            if (entity == null) return BadRequest("null");
            //string img = ServiceManager.UploadFileService.UploadFile(entity.File, "User");

            Console.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhh"+entity.username);
           // var json = _customConventer.DecodeJson<UserVm>(entity.id);

       
            var obj=new  UserCreateDto();
             obj = new UserCreateDto
             {

            Id = entity.id,
            Username = entity.username,
            Password = entity.password,
            Image = "",
            Email = entity.email,
            FirstName = entity.firstName,
            LastName = entity.lastName,
            PhoneNumber = entity.phoneNumber,
            UserType = entity.userType,
            Active = entity.active,
            State = entity.state,
            Status = entity.status,
            ConfeirmPassword = entity.confeirmPassword,
        };


         

            var result = await ServiceManager.UserService.Add(obj);
        
             


            if (result.Succeeded)
            {
                var ss = new UserTokenRequest
                {
                    Id = result.Data.Id,
                    Email = entity.email,
                    UserName = entity.username,
                    Password = entity.password,
                    Status = entity.status,
                    Image = entity.image,
                };

                var token = await _jwtTokenManager.GenerateClaimsTokenAsync(ss, CancellationToken.None);

                 var users = await _userManager.FindByIdAsync(result.Data.Id);
                 await _userManager.AddToRoleAsync(users, "User");


                return Ok(token);
            }
            else
            {


                return BadRequest(result.Status);
            }
        }

        // PUT api/User/5
        //[Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UserViewModel entity)
        {
            var img = "";
            var oldimg = "";

            if (entity == null) return BadRequest("null");
            var json = _customConventer.DecodeJson<UserVm>(entity.userVm);
          //  if (entity.File != null)
            if (entity.imageUrl != null)
            {
                //string imgname = UploadProImage(obj.File, "Product", servname);
                img = entity.imageUrl;

                    //_uploadFileService.UploadFile(entity.File, "User"); 

            }


           
            var obj = new UserCreateDto();
            json.username = json.phoneNumber;
            oldimg = json.image;
            if (entity.imageUrl != null)
            {
                
                 obj = new UserCreateDto
                {
                     
                     Id = json.id,

                     Username = json.username,
                    Image = img,
                    Email = json.email,
                    FirstName = json.firstName,
                    LastName = json.lastName,
                    PhoneNumber = json.phoneNumber,
                    UserType = json.userType,
                    Active = json.active,
                    State = json.state,
                    Status = json.status,

                };
            }
            else {
                obj = new UserCreateDto
                {
                    Id = json.id,
                    Username = json.username,
                    Image = oldimg, 
                    Email = json.email,
                    FirstName = json.firstName,
                    LastName = json.lastName,
                    PhoneNumber = json.phoneNumber,
                    UserType = json.userType,
                    Active = json.active,
                    State = json.state,
                    Status = json.status,
                     
                };


            }
            var item = _mapper.Map<UserUpdateDto>(obj);

            var result = await ServiceManager.UserService.Update(item); 
            
            if (result.Succeeded)
            {
                //if (entity.File != null)
                if (entity.imageUrl != null)
                {

                  //   _uploadFileService.DeleteImageFile(oldimg, "User");

                }

                return Ok(result);
            }
            else
            {
              //  _uploadFileService.DeleteImageFile(oldimg, "User");

                return BadRequest(result.Status);
            }
        }   
        
        [HttpPost("ResetPassWord")]
        public async Task<IActionResult> ResetPassWord([FromBody] changepasswordVm entity)
        {

            if (entity == null) return BadRequest("null");

          
               
                    var obj = new ChangePassWordDto
                    {
                         Id=entity.Id,
                        CurrentPassword = entity.CurrentPassword,
                        NewPassword = entity.NewPassword,

                        ConfeirmPassword = entity.ConfeirmPassword,
                     
                    };

                    var result = await ServiceManager.UserService.ChangePassWord(obj);
                    if (result.Succeeded)
                    {
                        return Ok(result);
                    }
                    else 
                    {

                        return BadRequest(result.Status);
                    }
                
               
            

        }

        // DELETE api/User/5
       // [Authorize]
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await ServiceManager.UserService.Remove(Id);
                        
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
