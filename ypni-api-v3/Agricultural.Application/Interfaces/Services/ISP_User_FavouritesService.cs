using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.SP_User_Favourites;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_User_Favourites;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISP_User_FavouritesService
    {
        Task<IResult<SP_User_FavouritesQueryDto>> Add(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_User_FavouritesQueryDto>>> Find(Expression<Func<SP_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_User_FavouritesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_User_FavouritesQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_User_FavouritesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SP_User_FavouritesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable< ServiceProviderQueryDto>>> GetByIdSPInfo(string Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_User_FavouritesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SP_User_FavouritesQueryDto>> Update(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default);
    }
}
