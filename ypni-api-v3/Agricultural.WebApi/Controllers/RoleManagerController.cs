using Agricultural.Application.DTOs.Role;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagerController : BaseApiController
    {
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var res = await ServiceManager.RoleService.GetAll();
        
            if (res.Succeeded)
            {
                return Ok(res.Data);
            }
            return BadRequest(res);

        }

    
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RolesDto entity)
        {
            if (entity == null) return BadRequest("the data is null");
            var res = await ServiceManager.RoleService.AddRoleAsync(entity);
            if (res.Succeeded)
            {
                return Ok(res);
            }

            return BadRequest(res);

        }
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser([FromBody] UserAndRolesDto entity)
        {
            if (entity == null) return BadRequest("the data is null");
            var res = await ServiceManager.RoleService.AddRoleToUserAsync(entity);
            if (res.Succeeded)
            {
                return Ok(res);
            }

            return BadRequest(res);

        }
    }
}
