////////////////////////////////////////////////
///         Ibrahim AL-afif                ///
///         ib2050a@gmail.com            ///
///         +967 777 384 772           ///
/// generated CurrentUserService.cs  ///
//////////////////////////////////////
using System.Security.Claims;
using Agricultural.Application.Interfaces.Common;

namespace Agricultural.WebApi.Services
{
    public class CurrentUserService 
    {
        public string UserId { get; }
        public string? UserName { get; }
        public bool IsAuthenticated { get; }
        public string IpAddress { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            IpAddress = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress.ToString();
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }
    }
}
