using Agricultural.Application.Common;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.User;
using Agricultural.Application.Wrapper;
using Agricultural.Domain.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;


namespace Agricultural.Infrastructure.Identity
{
    public class UserManagerImpl : IUserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserManagerImpl(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IResult<ChangePassWordDto>> ChangePassWordAsync(ChangePassWordDto entity, CancellationToken cancellationToken = default) // I change this code for API
        {
            if (entity == null) return await Result<ChangePassWordDto>.FailAsync("ChangePassWord : Null Value ");
            try
            {
                var userInfo = await _userManager.FindByIdAsync(entity.Id);
             var ob=   await _userManager.ChangePasswordAsync(userInfo, entity.CurrentPassword, entity.NewPassword);
                if(ob.Succeeded)
                {
                    return await Result<ChangePassWordDto>.SuccessAsync(entity, "ChangePassWord records retrieved");

                }
                else
                {
                    return await Result<ChangePassWordDto>.FailAsync("CurrentPassword Incorrect ");

                }


            }
            catch (Exception ex)
            {
                return await Result<ChangePassWordDto>.FailAsync($"catch ChangePassWord in user {ex.Message}");
            }
        }
        public async Task<IResult<ChangePassWordAdminDto>> ChangePassWordAdminAsync(ChangePassWordAdminDto entity, CancellationToken cancellationToken = default) // I change this code for API
        {
            if (entity == null) return await Result<ChangePassWordAdminDto>.FailAsync("ChangePassWord : Null Value ");
            try
            {
                var userInfo = await _userManager.FindByIdAsync(entity.Id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(userInfo);
                await _userManager.ResetPasswordAsync(userInfo, token, entity.NewPassword);
                return await Result<ChangePassWordAdminDto>.SuccessAsync(entity, "ChangePassWord records retrieved");
            }
            catch (Exception ex)
            {
                return await Result<ChangePassWordAdminDto>.FailAsync($"catch ChangePassWord in user {ex.Message}");
            }
        }
        public async Task<IResult<UserDto>> AddAsync(UserCreateDto entity, CancellationToken cancellationToken = default) // I change this code for API
        {
            if (entity == null) return await Result<UserDto>.FailAsync("AddUser : Null Value ");
            try
            {
                var oldUser = await _userManager.FindByNameAsync(entity.Username);
                if (oldUser != null)
                {
                    return await Result<UserDto>.FailAsync("userName already taken ", 800); 
                }
                oldUser = await _userManager.FindByEmailAsync(entity.Email);
                if (oldUser != null)
                {
                    return await Result<UserDto>.FailAsync("Email already taken ", 801);
                }
                string pass = entity.Password;
                entity.Password = null;
                var usermap = new User
                {
                    UserName = entity.Username,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                    Image = entity.Image,
                    UserType = entity.UserType,
                    State = entity.State,

                };
                var newEntity = await _userManager.CreateAsync(usermap, pass);
                if (!newEntity.Succeeded)
                {
                    string error = string.Empty;
                    foreach (var er in newEntity.Errors)
                    {
                        error = er.Description;
                    }
                    return await Result<UserDto>.FailAsync($"something went erro !!!\n\n\n{error}  ");
                }
                else
                {
                    var user = await _userManager.FindByNameAsync(entity.Username);
                    var itemMap = _mapper.Map<UserDto>(user);
                    itemMap.Id = user.Id;
                    return await Result<UserDto>.SuccessAsync(itemMap, "user  added succssfully");
                }
            }
            catch (Exception ex)
            {
                return await Result<UserDto>.FailAsync($"catch addAsync in user {ex.Message}");
            }
        }
        //public async Task<IResult<UserQueryDto>> CurentUser( CancellationToken cancellationToken = default)
        //{
        //    var gj = new ApplicationUser();
        //  //  var items = await _userManager.Users();

        //}
            
            public async Task<IResult<IEnumerable<UserQueryDto>>> Find(Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<User, bool>>>(expression);

            var items = await _userManager.Users.Where(mapExpr).ToListAsync();

            var itemMap = _mapper.Map<IEnumerable<UserQueryDto>>(items);

            return await Result<IEnumerable<UserQueryDto>>.SuccessAsync(itemMap, "User records retrieved");
        }

        public async Task<IResult<DtResult<UserQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UserQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<User, bool>>>(expression);

            var items = await _userManager.Users.Where(mapExpr).Skip(dtRequest.start).Take(dtRequest.length).ToListAsync();

            var totalRecord = await _userManager.Users.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<UserQueryDto>>(items);

            var datatableReturned = DtResult<UserQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            return await Result<DtResult<UserQueryDto>>.SuccessAsync(datatableReturned, message: "Get User Datatable.", 200);
        }

        public async Task<IResult<UserQueryDto>> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(email))
                return await Result<UserQueryDto>.FailAsync("FindByEmail > email is NULL !!!");
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    return await Result<UserQueryDto>.FailAsync("FindByEmail > The User dosent Exiest !!!");

                //return await Result<UserQueryDto>.SuccessAsync(_mapper.Map<UserQueryDto>(user), "FindByEmail > User Found..");
                var result = new UserQueryDto
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    UserType = user.UserType,

                };

                return await Result<UserQueryDto>.SuccessAsync(result, "FindByEmail > User Found..");
            }
            catch (Exception exc)
            {

                return await Result<UserQueryDto>.FailAsync($"FindByEmail > The User dosent Exiest !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult<UserQueryDto>> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(id))
                return await Result<UserQueryDto>.FailAsync("FindById > Id is NULL !!!");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return await Result<UserQueryDto>.FailAsync("FindById > The User dosent Exiest !!!");

            return await Result<UserQueryDto>.SuccessAsync(_mapper.Map<UserQueryDto>(user), "FindById > User Found..");
        }
        public async Task<IResult<UserUpdateDto>> FindByIdUserUpdateDto(string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(id))
                return await Result<UserUpdateDto>.FailAsync("FindById > Id is NULL !!!");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return await Result<UserUpdateDto>.FailAsync("FindById > The User dosent Exiest !!!");

            return await Result<UserUpdateDto>.SuccessAsync(_mapper.Map<UserUpdateDto>(user), "FindById > User Found..");
        }
        public async Task<IResult<IEnumerable<UserQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _userManager.Users.ToListAsync();
            if (items.Any())
            {
                var itemMap = _mapper.Map<IEnumerable<UserQueryDto>>(items);

                return await Result<IEnumerable<UserQueryDto>>.SuccessAsync(itemMap, "User records retrieved");
            }
            return await Result<IEnumerable<UserQueryDto>>.FailAsync("user is null");
        }

        public async Task<IResult<DtResult<UserQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            var items = await _userManager.Users.Select(x => new UserQueryDto
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Image = x.Image,
                UserType = x.UserType
            }).Skip(dtRequest.start).Take(dtRequest.length).ToListAsync();

            var totalRecord = await _userManager.Users.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<UserQueryDto>>(items);

            var datatableReturned = DtResult<UserQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            return await Result<DtResult<UserQueryDto>>.SuccessAsync(datatableReturned, message: "Get User Datatable.", 200);
        }

        public async Task<IResult<IEnumerable<UserDDLViewModel>>> GetDDL(CancellationToken cancellationToken = default)
        {
            var item = await _userManager.Users.Select(x => new UserDDLViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToListAsync();

            if (item == null) return await Result<IEnumerable<UserDDLViewModel>>.FailAsync("GetUserDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<UserDDLViewModel>(item);

            return await Result<IEnumerable<UserDDLViewModel>>.SuccessAsync(item, "User DDL records retrieved");
        }

        public Task<IResult<UserQueryDto>> GetUserAsync(CancellationToken cancellationToken = default)
        {
           // var user = _userManager.GetUserAsync(User);
            throw new NotImplementedException();
        }

        public async Task<IResult<UserQueryDto>> RemoveAsync(string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(id))
                return await Result<UserQueryDto>.FailAsync("Remove > Id is NULL !!!");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return await Result<UserQueryDto>.FailAsync("Remove > The User dosent Exiest !!!");

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return await Result<UserQueryDto>.SuccessAsync("Remove > User Deleted OK..");
            }

            return await Result<UserQueryDto>.FailAsync("Remove > error while tring delete user !!!"); ;
        }

        public async Task<IResult<UserUpdateDto>> UpdateAsync(UserUpdateDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<UserUpdateDto>.FailAsync($"UpdateUser > the passed entity IS NULL!!!...");

            var item = await _userManager.FindByIdAsync(entity.Id);

            if (item == null) return await Result<UserUpdateDto>.FailAsync("UpdateUser > the passed entity with the given id NOT EXIEST !!!.");



            _mapper.Map(entity, item);

            try
            {

                var result = await _userManager.UpdateAsync(item);

                if (result.Succeeded)
                {
                    return await Result<UserUpdateDto>.SuccessAsync(_mapper.Map<UserUpdateDto>(item), "User record updated");
                }


                return await Result<UserUpdateDto>.FailAsync($"UpdateUser > Something went wrong !!! Cannot update\n\n\n{result.Errors.Select(x => x.Description + '\n')}");
            }
            catch (Exception exc)
            {
                return await Result<UserUpdateDto>.FailAsync($"UpdateUser > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
    }
}
