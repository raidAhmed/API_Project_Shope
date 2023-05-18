

using Agricultural.Application.Auth;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using Agricultural.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agricultural.Infrastructure.Oauth
{
    public class JwtTokenManager : IJwtTokenManager
    {


        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationParameters _tokenValidationParameter;

        public JwtTokenManager(IConfiguration configuration, UserManager<User> userManager, TokenValidationParameters tokenValidationParameter)
        {

            _configuration = configuration;
            _userManager = userManager;
            _tokenValidationParameter = tokenValidationParameter;
        }


        public async Task<IResult<ClaimsPrincipal>> GetPrincipFromTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var tokenValidationParameter = _tokenValidationParameter.Clone();
                tokenValidationParameter.ValidateLifetime = false;
                var principle = tokenHandler.ValidateToken(token, tokenValidationParameter, out var validateToken);

                if (!IsJwtWithValidSecurityAlgorithm(validateToken))
                {
                    return await Result<ClaimsPrincipal>.FailAsync("Token Not Valid ");
                }
                return await Result<ClaimsPrincipal>.SuccessAsync(principle, "Get Princepl From Token Valid");
            }
            catch (Exception ex)
            {
                return await Result<ClaimsPrincipal>.FailAsync($"catch Token Note Valid  {ex.Message}");
            }
        }


        public async Task<IResult<AuthResult>> GenerateClaimsTokenAsync(UserTokenRequest UserTokenRequest, CancellationToken cancellationToke)    //Generare Token to user
        {
        
           
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var signingCredentials = GetSigningCredentials();
         
            var claims = await GetClaims(UserTokenRequest);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims.ClaimList);
            var refreshToken = GenerateRefreashTokenOptions(signingCredentials, claims.ClaimList);
            var res = new AuthResult
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                TokenType = "Bearer",
                ExpiresIn = DateTime.UtcNow.AddDays(Convert.ToDouble(jwtSettings["expiresIn"])).AddYears(1),
                RefreshTokenExpiresIn = DateTime.UtcNow.AddDays(Convert.ToDouble(jwtSettings["expiresIn"])).AddYears(3),
                CreationTime = DateTime.Now,
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                user = claims.userData,
                userid = UserTokenRequest.Id,
            };
          //  Console.WriteLine(res.user.FirstName);
            return await Result<AuthResult>.SuccessAsync(res, "Get Princepl From Token Valid");
        }
       
        private async Task<UserClaim> GetClaims(UserTokenRequest UserTokenRequest)   //Get user and his role
        {
            var user = await _userManager.FindByNameAsync(UserTokenRequest.UserName);
           
            var UserClaim = new UserClaim();
      
            UserClaim.ClaimList = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };
         
            var roles = await _userManager.GetRolesAsync(user);
            if (roles != null)
            {
                foreach (var role in roles)
                {


                    UserClaim.ClaimList.Add(new Claim(ClaimTypes.Role, role));

                    UserClaim.userData = new UserDto
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Id = user.Id,
                        Image = user.Image,
                        PhoneNumber = user.PhoneNumber,
                        State = user.State.GetValueOrDefault(),
                        UserType = role



                    };
                }
            }
            else
            {


                UserClaim.userData = new UserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    State = user.State.GetValueOrDefault(),
                    UserType = "null",



                };
            }

            return UserClaim;
        }


        private SigningCredentials GetSigningCredentials()//get the secret key and algorithm
        {
            var jwtConfig = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)//generate token 
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(Convert.ToDouble(jwtSettings["expiresIn"])).AddYears(1),
            signingCredentials: signingCredentials
            );


            return tokenOptions;
        }

        private JwtSecurityToken GenerateRefreashTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)// generate Refresh Token 
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var refreshToken = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(Convert.ToDouble(jwtSettings["expiresIn"])).AddYears(3),
            signingCredentials: signingCredentials

            );

            return refreshToken;
        }
        public static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validateToken)
        {
            return (validateToken is JwtSecurityToken jwtSecurityToken) && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

    }

}
