using Agricultural.Application.Common;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : BaseApiController
    {



            

        [HttpGet("Config")]
        public async Task<IActionResult> Config()
        {
            var result = await ServiceManager.ConfigService.GetConfig();    

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

    }
}
