using Agricultural.Application.Auth;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.ViewModels.User;
using Agricultural.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Common
{
    public interface ICurrentUserServices
    {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Image { get; set; }
            public bool Status { get; set; }

       void FindbyIdasync(UserTokenRequest user,CancellationToken cancellationToken = default);
       void CreateUsersync(UserDto user,CancellationToken cancellationToken = default);
    }
}
