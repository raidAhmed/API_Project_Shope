using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_User_Favourites;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_User_FavouritesRepository: IGenericRepository<Product_User_Favourites>
    {
        
        Task<IEnumerable<Product_User_FavouritesDDlLViewModels>> GetDDL();
    }
}
