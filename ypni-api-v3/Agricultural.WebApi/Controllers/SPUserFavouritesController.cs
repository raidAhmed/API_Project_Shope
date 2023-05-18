using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.SP_User_Favourites;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPUserFavouritesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.SP_User_FavouritesService.GetAll();

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
            var result = await ServiceManager.SP_User_FavouritesService.GetAll(dtRequest);

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
            var result = await ServiceManager.SP_User_FavouritesService.GetDDL();

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
           
            var result = await ServiceManager.SP_User_FavouritesService.GetByIdSPInfo(Id);
            if (result.Succeeded)
            {
                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        
                    }
                }

                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }



        // POST api/ActivityType

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] SP_User_FavouritesDto entity)
        {


            if (entity == null) return BadRequest("null");
            try
            {

                var result = await ServiceManager.SP_User_FavouritesService.Add(entity);


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
        public async Task<IActionResult> Put([FromBody] SP_User_FavouritesDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.SP_User_FavouritesService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.SP_User_FavouritesService.Remove(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        [HttpPost("DeleteByUserId")]
        public async Task<IActionResult> DeleteByUserId(int Id, string UserId)
        {
            var result = await ServiceManager.SP_User_FavouritesService.Find(x => x.ServiceProviderId == Id && x.UserId == UserId); 
            var res = result.Data.FirstOrDefault(); 
            var res2 = await ServiceManager.SP_User_FavouritesService.Remove(res.Id);

            if (res2.Succeeded)
            {
                return Ok(res2);
            }
            else
            {
                return BadRequest(res2.Status);
            }
        }
    }
}
