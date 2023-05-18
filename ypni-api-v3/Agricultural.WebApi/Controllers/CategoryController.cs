using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {

        [HttpGet("GetByIdSPandmainclassficationInfo/{Id}")]
        public async Task<IActionResult> GetByIdSPandmainclassficationInfo(int Id)
        {
            var result = await ServiceManager.SP_AdditionalSectionsService.GetByIdSPInfo(Id);

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
