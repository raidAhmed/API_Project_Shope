
using Agricultural.Application.Auth;
using System.Security.Claims;


namespace Agricultural.Application.Interfaces.Common
{
    public interface IJwtTokenManager
    {
        Task<IResult<AuthResult>> GenerateClaimsTokenAsync(UserTokenRequest userTokenRequst, CancellationToken cancellationToken);
       // Task<IResult<ClaimsPrincipal>> GetPrincipFromTokenAsync(string token);
    }
}
