
using Microsoft.AspNetCore.Identity;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Auth;
using Agricultural.Domain.Entity;

namespace Agricultural.Infrastructure.Identity
{
    public class SigninManager : ISignInManager
    {
        private readonly SignInManager<User> _signInManager;

        public SigninManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public async void SignOutAsync(CancellationToken cancellationToken = default)
        {
            _signInManager.SignOutAsync();
        }

        public async Task<IResult<UserTokenRequest>> PasswordSiginAsync(string username, string password, bool isPerisistent, bool LockOutoNFauilar)
        {
            try
            {

                var user = await _signInManager.UserManager.FindByNameAsync(username);
                if (user == null)
                {
                    Console.WriteLine($"the user that has this username {username} not Exsit ");
                    return await Result<UserTokenRequest>.FailAsync($"the user that has this username {username} not Exsit ");

                }

                var res = await _signInManager.CheckPasswordSignInAsync(user, password, LockOutoNFauilar);


                if (res.IsLockedOut)
                {
                    return await Result<UserTokenRequest>.FailAsync("acount lock too many atmate");
                }

                if (res.Succeeded)
                {
                    var userR = new UserTokenRequest
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Password = password,
                        UserName = user.UserName,
                        Image = user.Image,

                    };
                    if (user.Active != null)
                    {

                        if (!user.Active.Value)
                        {

                            return await Result<UserTokenRequest>.FailAsync("Sorry user not active yet please activate your Account");
                        }
                        return await Result<UserTokenRequest>.SuccessAsync(userR, "UserTokenRequest");
                    }
                    else { return await Result<UserTokenRequest>.FailAsync("Sorry user has no active yet please activate your Account"); }
                }


                else
                {
                    return Result<UserTokenRequest>.Fail("invalid Login ", 401);
                }
            }
            catch (Exception ex)
            {

                return await Result<UserTokenRequest>.FailAsync($"catch sgin by username Login {ex.Message}");

            }
        }

        public async Task<IResult<UserTokenRequest>> PasswordSignInByEmailAsync(string email, string password, bool isPersistent, bool LockoutOnFailiure)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user == null)
                return await Result<UserTokenRequest>.FailAsync("Account Locked, too many invalid login attempts.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, LockoutOnFailiure);

            if (result.IsLockedOut)
            {
                return await Result<UserTokenRequest>.FailAsync("Account Locked, too many invalid login attempts.");
            }

            return result.Succeeded
                ? Result<UserTokenRequest>.Success(new UserTokenRequest
                {
                    Id = user.Id,
                    Email = email,
                    Password = password,
                    UserName = user.UserName
                })
                : Result<UserTokenRequest>.Fail("Invalid Login Attempt.", 401);
        }

        public async Task<bool> LockedOut(User user, CancellationToken cancellationToken = default)
        {
            return await _signInManager.UserManager.IsLockedOutAsync(user);
        }
    }
}
