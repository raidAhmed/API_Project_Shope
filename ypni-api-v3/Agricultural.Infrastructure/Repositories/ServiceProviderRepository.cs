using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ServiceProvider;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Infrastructure.Repositories
{
    public class ServiceProviderRepository : GenericRepository<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(ApplicationDbContext context) : base(context)
        {
        }



        public Task<IEnumerable<ServiceProviderDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}
