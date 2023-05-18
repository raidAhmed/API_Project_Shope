using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SP_User_Favourites;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SP_User_FavouritesRepository : GenericRepository<SP_User_Favourites>,ISP_User_FavouritesRepository
    {
        public SP_User_FavouritesRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<SP_User_FavouritesDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}
