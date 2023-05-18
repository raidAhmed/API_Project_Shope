using Agricultural.Application.Auth;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Common
{
    public interface ISignInManager
    {
        Task<bool> LockedOut(User user, CancellationToken cancellationToken = default);
        void SignOutAsync(CancellationToken cancellationToken = default);
        Task<IResult<UserTokenRequest>> PasswordSiginAsync(string username, string password, bool isPerisistent, bool LockOutoNFauilar);
        Task<IResult<UserTokenRequest>> PasswordSignInByEmailAsync(string username, string password, bool isPersistent, bool LockoutOnFailiure);
    }
}
