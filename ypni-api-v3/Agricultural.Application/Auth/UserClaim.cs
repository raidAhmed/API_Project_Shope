using Agricultural.Application.DTOs.User;

using System.Security.Claims;


namespace Agricultural.Application.Auth
{
    public class UserClaim
    {
        public List<Claim> ClaimList { get; set; }
        public UserDto userData { get; set; }
    }
}
