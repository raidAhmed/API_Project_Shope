using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Auth
{
    public class UserTokenRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
