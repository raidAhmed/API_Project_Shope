using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.City;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }

     

        public async Task<IEnumerable<CityDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<City>().Select(x => new CityDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}
