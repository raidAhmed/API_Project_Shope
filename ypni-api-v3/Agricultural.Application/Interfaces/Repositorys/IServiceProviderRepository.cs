using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ServiceProvider;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IServiceProviderRepository: IGenericRepository<ServiceProvider>
    {
 
        Task<IEnumerable<ServiceProviderDDlLViewModels>> GetDDL();
    }
}
