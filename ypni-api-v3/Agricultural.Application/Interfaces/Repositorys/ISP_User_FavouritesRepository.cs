using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_User_Favourites;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISP_User_FavouritesRepository: IGenericRepository<SP_User_Favourites>
    {
        Task<IEnumerable<SP_User_FavouritesDDlLViewModels>> GetDDL();
    }
}
