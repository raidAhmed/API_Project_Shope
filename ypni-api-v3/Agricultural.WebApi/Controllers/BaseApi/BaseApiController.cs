 

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Agricultural.Application.Interfaces.Common;

namespace Agricultural.WebApi.Controllers.BaseApi
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IServiceManager _serviceManager { get; set;}

        protected IServiceManager ServiceManager => _serviceManager ??= HttpContext.RequestServices.GetRequiredService<IServiceManager>();

    }
}
