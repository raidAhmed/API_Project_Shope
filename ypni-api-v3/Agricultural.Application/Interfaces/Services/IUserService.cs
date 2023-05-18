

using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.User;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IResult<ChangePassWordDto>> ChangePassWord(ChangePassWordDto entity, CancellationToken cancellationToken = default);
        Task<IResult<ChangePassWordAdminDto>> ChangePassWordAdmin(ChangePassWordAdminDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserDto>> Add(UserCreateDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserQueryDto>>> Find(Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UserQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UserQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);

        Task<IResult<UserQueryDto>> GetById(string Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserDDLViewModel>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult<UserQueryDto>> Remove(string Id, CancellationToken cancellationToken = default);


        Task<IResult<UserUpdateDto>> Update(UserUpdateDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(UserCreateDto entity, CancellationToken cancellationToken = default);
    }
}
