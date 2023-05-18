////////////////////////////////////////////////
//////////////////////////////////////
using Agricultural.Application.DTOs.User;
///         Ibrahim AL-afif                ///
///         ib2050a@gmail.com            ///
///         +967 777 384 772           ///
///    generated AuthResult.cs       ///
namespace Agricultural.Application.Auth
{
    public class AuthResult
    {
        public UserDto user { get; set; }
        public string userid { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpiresIn { get; set; }
        public DateTime RefreshTokenExpiresIn { get; set; }
        public DateTime CreationTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
