using Agricultural.Application.DTOs.Role;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using Agricultural.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Agricultural.Infrastructure.Identity
{

    public class RoleManagerImp : IRolesManager
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;


        public RoleManagerImp(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default)
        {
            try
            {
                Console.WriteLine($"add role async in ropsitory  {entity.Name}");

                if (entity == null) return await Result<RolesDto>.FailAsync("role entity is null");
                var roleEntity = new IdentityRole
                {
                    // Id = entity.Id,
                    Name = entity.Name,
                };
                var res = await _roleManager.CreateAsync(roleEntity);
                if (!res.Succeeded)
                {
                    string error = string.Empty;
                    foreach (var er in res.Errors)
                    {

                        error = er.Description;


                    }
                    return await Result<RolesDto>.FailAsync($"Roles something went erro !!!\n\n\n{error}  ");

                }
                else
                {

                    var item = await _roleManager.FindByNameAsync(entity.Name);
                    var itemMap = new RolesDto
                    {

                        Name = entity.Name,
                    };

                    return await Result<RolesDto>.SuccessAsync("Role Created succssfully");
                }
                // return await Result<RolesDto>.FailAsync("Sorry Role Not add", 711);
            }
            catch (Exception ex)
            {
                return await Result<RolesDto>.FailAsync($"catch AddRoleAsync something Error {ex.InnerException.Message} ");
            }
        }

        public async Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(entity.UserId);


                if (user != null)
                {
                    if (user.Active != null)
                    {

                        if (user.Active.Value)
                        {


                            var roles = await _roleManager.RoleExistsAsync(entity.RoleName);

                            if (roles)
                            {
                                var userRes = await _userManager.AddToRoleAsync(user, entity.RoleName);
                                if (!userRes.Succeeded)
                                {
                                    string error = string.Empty;
                                    foreach (var er in userRes.Errors)
                                    {

                                        error = er.Description;


                                    }
                                    return await Result<UserAndRolesDto>.FailAsync($"UserAndRoles something went erro !!!\n\n\n{error}  ");
                                }
                                else
                                {
                                    // var itemMap=await _userManager.get

                                    return await Result<UserAndRolesDto>.SuccessAsync("UserAndRoles Created succssfully");
                                }
                            }
                            else
                            {
                                return await Result<UserAndRolesDto>.FailAsync($"Sorry this RoleName {entity.RoleName} Not Exsit");
                            }


                        }
                        else
                        {
                            return await Result<UserAndRolesDto>.FailAsync("Sorry user not active yet! \n\n please activate this user");
                        }


                    }
                    else
                    {
                        return await Result<UserAndRolesDto>.FailAsync("Sorry user has no active value active yet! \n\n please activate this user");
                    }

                }
                return await Result<UserAndRolesDto>.FailAsync($"Sorry! --> this User Not Exsit  ", 801);
            }
            catch (Exception ex)
            {
                return await Result<UserAndRolesDto>.FailAsync($"catch UserAndRoles something Error {ex.InnerException.Message}");
            }
        }

        public async Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var res = await _roleManager.Roles.AsNoTracking().ToListAsync();
                if (res.Any())
                {
                    var roles = new List<RolesDto>();
                    foreach (var role in res)
                    {
                        var itemMap = new RolesDto
                        {
                            Id = role.Id,
                            Name = role.Name,

                        };
                        roles.Add(itemMap);
                    }
                    return await Result<IEnumerable<RolesDto>>.SuccessAsync(roles, "roles record");
                }
                return await Result<IEnumerable<RolesDto>>.FailAsync($"roles record null ");
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<RolesDto>>.FailAsync($"catch error {ex.Message}", 712);
            }
        }

        public async Task<IResult<RolesDto>> GetRoleByIdAsync(string Id)
        {
            var item = await _roleManager.FindByIdAsync(Id);

            if (item == null) return await Result<RolesDto>.FailAsync("RolesDto > the given id NOT EXIEST !!!...");
            await _roleManager.DeleteAsync(item);
            var itemMap = new RolesDto();
            return await Result<RolesDto>.SuccessAsync(itemMap, "RolesDto record retrieved");
        }

        public async Task<IResult<RolesDto>> GetRoleByUserAsync(string Id)
        {
            try
            {


                throw new NotImplementedException();
                // var res=await _roleManager.r

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

        public Task<IResult<RolesDto>> RemoveRoleAsync(RolesDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<RolesDto>> UpdateRoleAsync(RolesDto entity)
        {
            throw new NotImplementedException();
        }
    }

}
