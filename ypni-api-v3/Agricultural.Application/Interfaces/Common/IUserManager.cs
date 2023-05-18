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
    public interface IUserManager
    {
        Task<IResult<ChangePassWordDto>> ChangePassWordAsync(ChangePassWordDto entity, CancellationToken cancellationToken = default);
        Task<IResult<ChangePassWordAdminDto>> ChangePassWordAdminAsync(ChangePassWordAdminDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserDto>> AddAsync(UserCreateDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserQueryDto>> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IResult<UserUpdateDto>> FindByIdUserUpdateDto(string id, CancellationToken cancellationToken = default);
        Task<IResult<UserQueryDto>> GetUserAsync(CancellationToken cancellationToken = default);
        Task<IResult<UserQueryDto>> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IResult<UserQueryDto>> RemoveAsync(string id, CancellationToken cancellationToken = default);// change for Api
        /// <summary>
        /// ///////////////////////////
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IResult<IEnumerable<UserQueryDto>>> Find(Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UserQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UserQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UserQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);

        Task<IResult<IEnumerable<UserDDLViewModel>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult<UserUpdateDto>> UpdateAsync(UserUpdateDto entity, CancellationToken cancellationToken = default);
    }
}
