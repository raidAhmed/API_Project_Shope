using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ProFeatures;
using Agricultural.Application.ViewModels.ServicesType;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ServiceTypeRepository : GenericRepository<ServicesType>, IServicesTypeRepository
    {
        public ServiceTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ServicesTypeDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ServicesType>().Select(x => new ServicesTypeDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}
