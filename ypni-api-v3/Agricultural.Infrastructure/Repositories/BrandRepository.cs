using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ActivityType;
using Agricultural.Application.ViewModels.Brand;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>,IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BrandDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Brand>().Select(x => new BrandDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}
