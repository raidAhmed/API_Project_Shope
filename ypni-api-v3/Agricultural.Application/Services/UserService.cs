

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Agricultural.Domain.Entity;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.ViewModels.User;

namespace Agricultural.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;

        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<IResult<ChangePassWordDto>> ChangePassWord(ChangePassWordDto entity, CancellationToken cancellationToken = default)
        {



            return await _userManager.ChangePassWordAsync(entity, cancellationToken);


        }
        public async Task<IResult<ChangePassWordAdminDto>> ChangePassWordAdmin(ChangePassWordAdminDto entity, CancellationToken cancellationToken = default)
        {



            return await _userManager.ChangePassWordAdminAsync(entity, cancellationToken);


        }
        public async Task<IResult<IEnumerable<UserQueryDto>>> Find(Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            return await _userManager.Find(expression, cancellationToken);
        }

        public async Task<IResult<DtResult<UserQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            return await _userManager.Find(dtRequest, expression, cancellationToken);
        }

        public async Task<IResult<IEnumerable<UserQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {

            return await _userManager.GetAll(cancellationToken);
        }


        public async Task<IResult<DtResult<UserQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            return await _userManager.GetAll(dtRequest, cancellationToken);

        }

        public async Task<IResult<UserQueryDto>> GetById(string Id, CancellationToken cancellationToken = default)
        {

            return await _userManager.FindByIdAsync(Id, cancellationToken);
        }

        public async Task<IResult<IEnumerable<UserDDLViewModel>>> GetDDL(CancellationToken cancellationToken = default)
        {

            return await _userManager.GetDDL(cancellationToken);
        }
        public async Task<IResult<UserDto>> Add(UserCreateDto entity, CancellationToken cancellationToken = default)
        {

          

            return await _userManager.AddAsync(entity, cancellationToken);


        }

        public async Task<IResult<UserQueryDto>> Remove(string Id, CancellationToken cancellationToken = default)
        {
            return await _userManager.RemoveAsync(Id, cancellationToken);
        }

        public async Task<IResult<UserUpdateDto>> Update(UserUpdateDto entity, CancellationToken cancellationToken = default)
        {
            return await _userManager.UpdateAsync(entity, cancellationToken);
        }

        public Task<IResult> ChangeActive(UserCreateDto entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
