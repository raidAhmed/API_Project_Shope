using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_User_Favourites;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_User_FavouritesRepository : GenericRepository<Product_User_Favourites>,IProduct_User_FavouritesRepository
    {
        public Product_User_FavouritesRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_User_FavouritesDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}
