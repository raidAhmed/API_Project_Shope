using Agricultural.Application.DTOs.Role;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.Wrapper;

namespace Agricultural.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRolesManager _roleManager;

        public RoleService(IRolesManager roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<RolesDto>.FailAsync("role entity is empty");
            try
            {
                var role = await _roleManager.AddRoleAsync(entity, cancellationToken);
                if (role.Succeeded)
                {
                    return await Result<RolesDto>.SuccessAsync("Role added");
                }
                return await Result<RolesDto>.FailAsync(role.Status.message, role.Status.code);
            }
            catch (Exception ex)
            {
                return await Result<RolesDto>.FailAsync($"role manger someThing error {ex.Message}");
            }
        }

        public async Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default)
        {

            var res = await _roleManager.AddRoleToUserAsync(entity, cancellationToken);
            if (res.Succeeded)

            {
                return await Result<UserAndRolesDto>.SuccessAsync(entity, "role added to user successFully");
            }
            return await Result<UserAndRolesDto>.FailAsync(res.Status.message, res.Status.code);

        }

        public async Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var role = await _roleManager.GetAll();
                Console.WriteLine($"result message {role.Status.message}");
                if (role.Succeeded)
                {
                    return await Result<IEnumerable<RolesDto>>.SuccessAsync(role.Data, "role data retrive");
                }
                return await Result<IEnumerable<RolesDto>>.FailAsync("no data there ");
            }
            catch (Exception ex)
            {

                return await Result<IEnumerable<RolesDto>>.FailAsync($"something error in role service {ex.Message}");

            }
        }

        public async Task<IResult<IEnumerable<UserAndRolesDto>>> GetAllRoleUserAsync(int Id)
        {

            throw new NotImplementedException();
        }

        public async Task<IResult<RolesDto>> GetRoleByIdAsync(string Id)
        {
            var role = await _roleManager.GetRoleByIdAsync(Id);
            return await Result<RolesDto>.SuccessAsync(role.Data, "role data retrive");
        }

        public async Task<IResult<RolesDto>> GetRoleByUserAsync(string Id)
        {
            throw new NotImplementedException();
            ///   var res=await _roleManager.
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
