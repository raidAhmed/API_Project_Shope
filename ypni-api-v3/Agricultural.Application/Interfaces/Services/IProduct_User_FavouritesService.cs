using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.Product_User_Favourites;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_User_Favourites;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_User_FavouritesService
    {
        Task<IResult<IEnumerable<Product_User_FavouritesDDlLViewModels>>> GetByIdSPInfo(string UserId, CancellationToken cancellationToken = default);
         
        Task<IResult<Product_User_FavouritesQueryDto>> Add(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_User_FavouritesQueryDto>>> Find(Expression<Func<Product_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_User_FavouritesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_User_FavouritesQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_User_FavouritesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_User_FavouritesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_User_FavouritesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<Product_User_FavouritesQueryDto>> Update(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default);
    }
}
