

using Agricultural.Application.DTOs.Role;


namespace Agricultural.Application.Interfaces.Common
{
    public interface IRolesManager
    {
        Task<IResult<RolesDto>> AddRoleAsync(RolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<UserAndRolesDto>> AddRoleToUserAsync(UserAndRolesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<RolesDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<RolesDto>> UpdateRoleAsync(RolesDto entity);
        Task<IResult<RolesDto>> RemoveRoleAsync(RolesDto entity);
        Task<IResult<RolesDto>> GetRoleByUserAsync(string Id);
        Task<IResult<RolesDto>> GetRoleByIdAsync(string Id);
    }
}
