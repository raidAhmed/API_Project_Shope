using Agricultural.Application.DTOs.Role;
using Agricultural.Application.Interfaces.Common;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default);
        //Task<IResult<RolesDto>> UpdateRoleAsync(RolesDto entity);
        //Task<IResult<RolesDto>> RemoveRoleAsync(RolesDto entity);
        Task<IResult<RolesDto>> GetRoleByUserAsync(string Id);
        Task<IResult<RolesDto>> GetRoleByIdAsync(string Id);
        Task<IResult<IEnumerable<UserAndRolesDto>>> GetAllRoleUserAsync(int Id);

    }
}
